using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NetChatServerLibrary
{
    public static class DatabaseConnection
    {
        static void Main()
        {
            /*
            string connectionString = "Server=172.0.0.1;Database=NCDB;Uid=root;Pwd=;";
            string query = "SELECT * FROM x WHERE x.ID = @param1";
    
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var param = new MySqlParameter("@param1", MySqlDbType.Int32) { Value = 32 };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(param);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        // gibt mir das object an der stelle 0
                        string x;
                        x = r.GetFieldValue<string>(0);
                        x = r.GetString(0);
                        x = (string)r[0];
                    }
                    // immer das erste objekt in der ersten Zeile
                    var s = com.ExecuteScalar();
                    // gibt mir die anzahl der veränderten Zeilen
                    int nq = com.ExecuteNonQuery();
                }
            }
            */

        }
    }
}