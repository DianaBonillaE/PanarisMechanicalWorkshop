using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MechanicalLibrary.Data
{
   public class VehicleData
    {
        String connectionString;
        public VehicleData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Insertar(Vehicle vehicle)
        {
            SqlCommand cmdClient = new SqlCommand();
            cmdClient.CommandText = "Mechanical_InsertVehicle";
            cmdClient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdClient.Parameters.Add(new SqlParameter("@vehicle_id", vehicle.VehicleId));
            cmdClient.Parameters.Add(new SqlParameter("@color", vehicle.Color));
            cmdClient.Parameters.Add(new SqlParameter("@brand", vehicle.Brand));
            cmdClient.Parameters.Add(new SqlParameter("@style", vehicle.Style));
            cmdClient.Parameters.Add(new SqlParameter("@year", vehicle.Year));
            cmdClient.Parameters.Add(new SqlParameter("@power", vehicle.Power));
            cmdClient.Parameters.Add(new SqlParameter("@displacement", vehicle.Displacement));
            cmdClient.Parameters.Add(new SqlParameter("@capacity", vehicle.Capacity));
            cmdClient.Parameters.Add(new SqlParameter("@weight", vehicle.Weight));
            cmdClient.Parameters.Add(new SqlParameter("@chasis_number", vehicle.ChasisNumber));
            cmdClient.Parameters.Add(new SqlParameter("@motor_number", vehicle.MotorNumber));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdClient.Connection = connection;
                cmdClient.Transaction = transaction;
                cmdClient.ExecuteNonQuery();
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
        }//fin insertar


    }
}
