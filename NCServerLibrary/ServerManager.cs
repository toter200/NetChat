using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NCServerLibrary
{
    class ServerManager
    {
        /*
        public static string GetIp(string email)
        {
            string connectionString = "Server=172.0.0.1;Database=NCDB;Uid=root;Pwd=;";
            string query = "SELECT d.ipAddress from dev d JOIN usr u ON u.id = d.userID WHERE u.username = @username OR u.mail = @email;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username };
                var mail = new MySqlParameter("@email", MySqlDbType.VarChar) { Value = email };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(usr);
                    com.Parameters.Add(mail);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        var x = r.GetFieldValue<string>(0);

                        return x;
                    }
                }
                return "172.0.0.1";
            }
        }
        */
        static string connectionString = "Server=172.0.0.1;Database=NCDB;Uid=root;Pwd=;";

        public static bool GetStatus(string email)
        {
            string query = "SELECT * FROM usr WHERE mail = @email;";

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@email", MySqlDbType.VarChar) { Value = email };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        var x = r.GetFieldValue<int>(0);

                        return x == 1;
                    }
                }
                return false;
            }
        }

        public static string GetIp(string email)
        {
            string query = "SELECT d.ipAddress from dev d JOIN usr u ON u.id = d.userID WHERE u.mail = @email;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@email", MySqlDbType.VarChar) { Value = email };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        var x = r.GetFieldValue<string>(0);

                        return x;
                    }
                }
                return "172.0.0.1";
            }
        }
        public static string GetUser(string email)
        {
            string query = "SELECT username FROM usr WHERE mail = @email;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@email", MySqlDbType.VarChar) { Value = email };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        var x = r.GetFieldValue<string>(0);

                        return x;
                    }
                }
                return "User";
            }
        }

        public static string GetEmail(string username)
        {
            string query = "SELECT mail FROM usr WHERE username = @username;";

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(usr);
                    var r = com.ExecuteReader();
                    while (r.Read())
                    {
                        var x = r.GetFieldValue<string>(0);

                        return x;
                    }
                }
                return "Mail";
            }
        }

        public static void CreateUser(string ipad, string username, string email)
        {
            string query = "INSERT INTO usr (mail, username, status) VALUES (@mail, @username, 1);";
            string query2 = "INSERT INTO dev (userID, ipAddress) VALUES ((SELECT id FROM usr WHERE mail=@mail), @ip);";

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username };
                var ip = new MySqlParameter("@ip", MySqlDbType.VarChar) { Value = ipad };
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = email };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(usr);
                    com.Parameters.Add(mail);
                    int i = com.ExecuteNonQuery();
                }

                using (var com = new MySqlCommand(query2, con))
                {
                    com.Parameters.Add(ip);
                    com.Parameters.Add(mail);
                    int i = com.ExecuteNonQuery();
                }
            }
        }

        public static void AlterEmail(string oldEmail, string newEmail)
        {
            string query = "SELECT username FROM usr WHERE mail = @email;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var nmail = new MySqlParameter("@nemail", MySqlDbType.VarChar) { Value = newEmail };
                var omail = new MySqlParameter("@oemail", MySqlDbType.VarChar) { Value = oldEmail };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(nmail);
                    com.Parameters.Add(omail);
                    int i = com.ExecuteNonQuery();
                }
            }
        }

    }
}
