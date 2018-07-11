using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MechanicalLibrary.Data
{
    public class ProductData
    {

        String connectionString;

        public ProductData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertarProducto(Product product)
        {
            //PRIMER COMANDO
            SqlCommand cmdProduct = new SqlCommand();
            cmdProduct.CommandText = "insertarProducto";
            cmdProduct.CommandType = System.Data.CommandType.StoredProcedure;
            cmdProduct.Parameters.Add(new SqlParameter("@name", product.Name));
            cmdProduct.Parameters.Add(new SqlParameter("@quantity", product.Quantity));
            cmdProduct.Parameters.Add(new SqlParameter("@order", product.Order));
            cmdProduct.Parameters.Add(new SqlParameter("@price", product.Price));
            cmdProduct.Parameters.Add(new SqlParameter("@id_work_detail", product.WorkDetail.IdWorkDetail));//OJO

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
