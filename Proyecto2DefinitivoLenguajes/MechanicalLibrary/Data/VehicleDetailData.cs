using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace MechanicalLibrary.Data
{
    public class VehicleDetailData
    {
        String connectionString;

        public VehicleDetailData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertarDetalleVehiculo(VehicleDetail vehicleDetail)
        {
            SqlCommand cmdProduct = new SqlCommand();
            cmdProduct.CommandText = "Proyecto2Mechanical_insertVehicleDetail";
            cmdProduct.CommandType = System.Data.CommandType.StoredProcedure;
            cmdProduct.Parameters.Add(new SqlParameter("@quantity", vehicleDetail.Quantity));
            cmdProduct.Parameters.Add(new SqlParameter("@observations", vehicleDetail.Observations));
            cmdProduct.Parameters.Add(new SqlParameter("@id_work_order", vehicleDetail.WorkOrder.IdWorkOrder));
            cmdProduct.Parameters.Add(new SqlParameter("@id_type_detail", vehicleDetail.TypeDetail.IdTypeDetail));
            cmdProduct.Parameters.Add(new SqlParameter("@id_condition", vehicleDetail.Condition.IdCondition));
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
            }

        }
    }
}
