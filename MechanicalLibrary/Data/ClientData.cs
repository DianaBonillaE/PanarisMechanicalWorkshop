using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MechanicalLibrary.Data
{
 public  class ClientData
    {
        String connectionString;

        public ClientData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Client Insertar(Client client)
        {
            SqlCommand cmdClient= new SqlCommand();
            cmdClient.CommandText = "Mechanical_InsertClient";
            cmdClient.CommandType = System.Data.CommandType.StoredProcedure;
            cmdClient.Parameters.Add(new SqlParameter("@id_client", client.IdClient));
            cmdClient.Parameters.Add(new SqlParameter("@client_name", client.ClientName));
            cmdClient.Parameters.Add(new SqlParameter("@last_name", client.LastName));
            cmdClient.Parameters.Add(new SqlParameter("@phone_number", client.PhoneNumber));
            cmdClient.Parameters.Add(new SqlParameter("@address", client.Address));
            cmdClient.Parameters.Add(new SqlParameter("@email", client.Email));
            SqlParameter parIdClient = new SqlParameter("@id_client",System.Data.SqlDbType.VarChar);
            parIdClient.Direction = System.Data.ParameterDirection.Output;
            cmdClient.Parameters.Add(parIdClient);

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
            return client;
        }//fin insertar
        
        public List<Client> GetAllClients()
        {
            String sqlSelect = "Select  * from Client";
            SqlDataAdapter daClients = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsClients = new DataSet();
            daClients.Fill(dsClients, "Client");

            Dictionary<String, Client> dictionary = new Dictionary<String, Client>();
            Client client = null;
            foreach(DataRow row in dsClients.Tables["Client"].Rows)
            {
                String id = row["id_client"].ToString();
                if (dictionary.ContainsKey(id) == false)
                {
                    client = new Client();
                    client.IdClient = id;
                    client.ClientName = row["client_name"].ToString();
                    client.LastName = row["last_name"].ToString();
                    client.PhoneNumber = row["phone_number"].ToString();
                    client.Address = row["address"].ToString();
                    client.Email = row["email"].ToString();
                    dictionary.Add(id, client);
                }//if
            }//for
            return dictionary.Values.ToList<Client>();
        }//getAll
    }
}
