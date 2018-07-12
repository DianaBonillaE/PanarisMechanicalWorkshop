using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MechanicalLibrary.Data
{
    public class WorkOrderData
    {

        String connectionString;

        public WorkOrderData(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IList<WorkOrder> GetWorkOrders()
        {

            IList<WorkOrder> lista;
            WorkOrder workOrder;
            SqlCommand cmdWorkOrder = new SqlCommand();
            cmdWorkOrder.CommandText = "getAllWorkOrder";
            cmdWorkOrder.CommandType = System.Data.CommandType.StoredProcedure;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            cmdWorkOrder.Connection = connection;
            SqlDataReader myReader;
            myReader = cmdWorkOrder.ExecuteReader();
            lista = new List<WorkOrder>();

            while (myReader.Read())
            {
                workOrder = new WorkOrder();
                workOrder.IdWorkOrder = myReader.GetInt32(0);
                workOrder.Description = myReader.GetString(1);
                lista.Add(workOrder);
            }
            myReader.Close();
            return lista;

        }

        public void InsertarOrdenTrabajo(WorkOrder workOrder)
        {
            SqlCommand cmdProduct = new SqlCommand();
            cmdProduct.CommandText = "Proyecto2Mechanical_insertWorkOrder";
            cmdProduct.CommandType = System.Data.CommandType.StoredProcedure;
            cmdProduct.Parameters.Add(new SqlParameter("@description", workOrder.Description));
            cmdProduct.Parameters.Add(new SqlParameter("@delivery_date", workOrder.DeliveryDate));
            cmdProduct.Parameters.Add(new SqlParameter("@client_id", workOrder.Client.IdClient));
            cmdProduct.Parameters.Add(new SqlParameter("@vehicle_id", workOrder.Vehicle.VehicleId));
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdProduct.Connection = connection;
                cmdProduct.Transaction = transaction;
                cmdProduct.ExecuteNonQuery();
                transaction.Commit();

            }
            catch (SqlException ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }//finally

        }

    }
}

