using MechanicalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MechanicalLibrary.Data
{
    public class ConditionData
    {
        String connectionString;
        public ConditionData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Condition> GetAllConditions()
        {
            String sqlSelect = "Select  * from Condition";
            SqlDataAdapter daConditions = new SqlDataAdapter(sqlSelect, new SqlConnection(connectionString));

            DataSet dsConditions = new DataSet();
            daConditions.Fill(dsConditions, "Condition");

            Dictionary<String, Condition> dictionary = new Dictionary<String, Condition>();
            Condition condition = null;
            foreach (DataRow row in dsConditions.Tables["Condition"].Rows)
            {
                int id = Int32.Parse(row["id_condition"].ToString());
                if (dictionary.ContainsKey(id+"") == false)
                {
                    condition = new Condition();
                    condition.IdCondition = id;
                    condition.Description = row["description"].ToString();
                    dictionary.Add(id+"", condition);
                }//if
            }//for
            return dictionary.Values.ToList<Condition>();
        }//getAll
    }
}
