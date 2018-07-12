using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MechanicalLibrary.Data
{
    public class TypeDetailData
    {
        String connectionString;

        public TypeDetailData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<TypeDetail> GetAllTypes()
        {
            String sqlSelect = "SELECT * FROM Type_Detail";
            SqlDataAdapter daTypes = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsTypes = new DataSet();
            daTypes.Fill(dsTypes, "Type_Detail");

            Dictionary<String, TypeDetail> dictionary = new Dictionary<String, TypeDetail>();
            TypeDetail typeDetail = null;
            foreach (DataRow row in dsTypes.Tables["Type_Detail"].Rows)
            {
                int id = Int32.Parse(row["id_type_detail"].ToString());
                if (dictionary.ContainsKey(id + "") == false)
                {
                    typeDetail = new TypeDetail();
                    typeDetail.IdTypeDetail = id;
                    typeDetail.Description = row["description"].ToString();
                    dictionary.Add(id + "", typeDetail);
                }//if
            }//for
            return dictionary.Values.ToList<TypeDetail>();
        }//getAll
    }
}
