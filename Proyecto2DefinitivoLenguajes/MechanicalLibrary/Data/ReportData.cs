using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MechanicalLibrary.Data
{
   public class ReportData
    {

        String connectionString;
        public ReportData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Report getReport(int idWorkOrder) {
            Report report=new Report();
            VehicleDetail vehicleDetail;

            SqlCommand cmdReport = new SqlCommand();
            cmdReport.CommandText = "ReporteGeneral";
            cmdReport.CommandType = System.Data.CommandType.StoredProcedure;
            cmdReport.Parameters.Add(new SqlParameter("@idOrdenTrabajo", idWorkOrder));
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            cmdReport.Connection = connection;
            SqlDataReader myReader;
            myReader = cmdReport.ExecuteReader();

            //Primer conjunto de resultados
            while (myReader.Read()) {

                if (report.WorkOrder.Vehicle.VehicleId==null) {

                    report.WorkOrder.Vehicle.VehicleId = myReader.GetString(0);
                    report.WorkOrder.Vehicle.Color= myReader.GetString(1);
                    report.WorkOrder.Vehicle.Brand = myReader.GetString(2);
                    report.WorkOrder.Vehicle.Style = myReader.GetString(3);
                    report.WorkOrder.Vehicle.Year = myReader.GetInt32(4).ToString();
                    report.WorkOrder.Vehicle.Power = myReader.GetString(5);
                    report.WorkOrder.Vehicle.Displacement = myReader.GetString(6);
                    report.WorkOrder.Vehicle.Capacity = myReader.GetInt32(7);
                    report.WorkOrder.Vehicle.Weight = myReader.GetInt32(8);
                    report.WorkOrder.Vehicle.ChasisNumber = myReader.GetString(9);
                    report.WorkOrder.Vehicle.MotorNumber = myReader.GetString(10);
                }
                vehicleDetail = new VehicleDetail();
                vehicleDetail.IdVehicleDetail= myReader.GetInt32(11);
                vehicleDetail.Quantity = myReader.GetInt32(12);
                vehicleDetail.Observations = myReader.GetString(13);
                vehicleDetail.TypeDetail.Description = myReader.GetString(14);
                vehicleDetail.Condition.Description = myReader.GetString(15);

                report.VehicleDetailList.Add(vehicleDetail);
            }

            //Avanzo a segundo conjunto de resultados
            myReader.NextResult();
            //Segundo conjunto de resultados
            WorkDetail workDetail;
            Product product;
            while (myReader.Read())
            {
                product = new Product();
                workDetail = new WorkDetail();
                if (report.WorkOrder.IdWorkOrder==0) {
                    report.WorkOrder.IdWorkOrder= myReader.GetInt32(0);
                    report.WorkOrder.Description = myReader.GetString(1);
                    report.WorkOrder.DeliveryDate = myReader.GetDateTime(2);
                    report.WorkOrder.TotalPrice = myReader.GetFloat(3);
                    //brinco 4 que es id client
                    //brinco 5 que es id vehicle, ya se insertó en reader anterior.
                    }
                workDetail.IdWorkDetail = myReader.GetInt32(6);
                workDetail.Price = myReader.GetFloat(7);
                workDetail.Description = myReader.GetString(8);
                report.WorkDetailList.Add(workDetail);

                product.IdProduct= myReader.GetInt32(9);
                product.Name = myReader.GetString(10);
                product.Quantity = myReader.GetInt32(11);
                product.Price = myReader.GetFloat(12);
                report.ProductList.Add(product);
            }

            //Avanzo a tercer conjunto de resultados
            myReader.NextResult();
            //Tercer conjunto de resultados

            while (myReader.Read()) {
                report.WorkOrder.Client.IdClient = myReader.GetString(0);
                report.WorkOrder.Client.ClientName = myReader.GetString(1);
                report.WorkOrder.Client.LastName = myReader.GetString(2);
                report.WorkOrder.Client.PhoneNumber = myReader.GetString(3);
                report.WorkOrder.Client.Address = myReader.GetString(4);
                report.WorkOrder.Client.Email = myReader.GetString(5);
            }

            return report;

        }

    }
}
