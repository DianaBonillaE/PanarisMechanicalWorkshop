using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MechanicalLibrary.Data
{
    public class WorkDetailData
    {

        String connectionString;

        public WorkDetailData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<WorkDetail> GetWorkDetailsByOrder(int id) {

            IList<WorkDetail> lista;
            WorkDetail workDetail;
            SqlCommand cmdWorkDetail = new SqlCommand();
            cmdWorkDetail.CommandText = "getAllWorkDetailById";
            cmdWorkDetail.CommandType = System.Data.CommandType.StoredProcedure;
            cmdWorkDetail.Parameters.Add(new SqlParameter("@id", id));
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            cmdWorkDetail.Connection = connection;
            SqlDataReader myReader;
            myReader = cmdWorkDetail.ExecuteReader();
            lista = new List<WorkDetail>();
     
            while (myReader.Read())
            {
                workDetail = new WorkDetail();
                workDetail.IdWorkDetail = myReader.GetInt32(0);
                workDetail.Description = myReader.GetString(1);
                lista.Add(workDetail);
            }
            myReader.Close();
            return lista;

        }


    }
}
