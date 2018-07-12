using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public List<Vehicle> GetAllVehicles()
        {
            String sqlSelect = "Select  * from Vehicle";
            SqlDataAdapter daVehicles = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsVehicles = new DataSet();
            daVehicles.Fill(dsVehicles, "Vehicle");

            Dictionary<String, Vehicle> dictionary = new Dictionary<String, Vehicle>();
            Vehicle vehicle = null;
            foreach (DataRow row in dsVehicles.Tables["Vehicle"].Rows)
            {
                String id = row["vehicle_id"].ToString();
                if (dictionary.ContainsKey(id) == false)
                {
                    vehicle = new Vehicle();
                    vehicle.VehicleId = id;
                    vehicle.Color = row["color"].ToString();
                    vehicle.Brand = row["brand"].ToString();
                    vehicle.Style = row["style"].ToString();
                    vehicle.Year = row["year"].ToString();
                    vehicle.Power = row["power"].ToString();
                    vehicle.Displacement = row["displacement"].ToString();
                    vehicle.Capacity = Int32.Parse(row["capacity"].ToString());
                    vehicle.Weight = Int32.Parse(row["weight"].ToString());
                    vehicle.ChasisNumber = row["chasis_number"].ToString();
                    vehicle.MotorNumber = row["motor_number"].ToString();
                    dictionary.Add(id, vehicle);
                }//if
            }//for
            return dictionary.Values.ToList<Vehicle>();
        }//getAll

    }
}
