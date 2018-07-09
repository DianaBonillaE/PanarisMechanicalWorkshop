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


        public IList<WorkOrder> GetWorkOrders(int id)
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

    }
}
