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
    public class ServerManager
    {
        static string connectionString = "Server=localhost;Database=ncdb;Uid=root;Pwd=Hs4e9FUMjA;";

        public static void CreateDatabase()
        {
            string connectionString = "Server=localhost; Database=; Uid=root; Pwd=Hs4e9FUMjA;";
            string query = "CREATE DATABASE ncdb; use ncdb; CREATE TABLE usr (id INT(6) AUTO_INCREMENT PRIMARY KEY, mail VARCHAR(60) NOT NULL, username VARCHAR(60) NOT NULL, status TINYINT(1) NOT NULL DEFAULT 1); CREATE TABLE dev (devID INT(6) AUTO_INCREMENT PRIMARY KEY, userID INT(6) NOT NULL REFERENCES usr(id), ipAddress VARCHAR(20) NOT NULL); SHOW COLUMNS FROM usr; SHOW COLUMNS FROM dev;";
            using (var con = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Open Database Connection... ");
                con.Open();
                Console.WriteLine("Connected Database");
                using (var com = new MySqlCommand(query, con))
                {
                    Console.WriteLine("Creating Database");
                    int i = com.ExecuteNonQuery();
                    Console.WriteLine("Database Created");
                }

            }
        }
        public static void DeleteDatabase()
        {
            string query = "drop DATABASE ncdb;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (var com = new MySqlCommand(query, con))
                {
                    int i = com.ExecuteNonQuery();
                    Console.WriteLine("Deleted Database");
                }

            }
        }
        public static bool GetStatus(string email)
        {
            string query = "SELECT status FROM usr WHERE mail = @email;";

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
                        var x = r.GetFieldValue<bool>(0);
                        return x;
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
        public static void CreateUser(string ipaddress, string username, string email)
        {
            string query = "INSERT INTO usr (mail, username, status) VALUES (@mail, @username, 1);";
            string query2 = "INSERT INTO dev (userID, ipAddress) VALUES ((SELECT id FROM usr WHERE mail=@mail), @ip);";

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username };
                var ip = new MySqlParameter("@ip", MySqlDbType.VarChar) { Value = ipaddress };
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
        public static void DeleteUser(string email)
        {
            string query = "DELETE FROM usr WHERE mail = @email;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@email", MySqlDbType.VarChar) { Value = email };
                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.ExecuteNonQuery();
                }
            }
        }
        public static void AlterEmail(string newEmail, string username)
        {
            string query = "UPDATE usr SET mail = @mail WHERE username = @username;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = newEmail };
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.Parameters.Add(usr);
                    int i = com.ExecuteNonQuery();
                }

            }
        }
        public static void AlterUsername(string newUsername, string email)
        {
            string query = "UPDATE usr SET username = @username WHERE mail = @mail;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = email };
                var usr = new MySqlParameter("@username", MySqlDbType.VarChar) { Value = newUsername };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.Parameters.Add(usr);
                    int i = com.ExecuteNonQuery();
                }

            }
        }
        public static void AlterIp(string newIp, string email)
        {
            string query = "UPDATE dev SET ipAddress = @ip WHERE userID = (SELECT id FROM usr WHERE mail = @mail);";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = email };
                var ip = new MySqlParameter("@ip", MySqlDbType.VarChar) { Value = newIp };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.Parameters.Add(ip);
                    int i = com.ExecuteNonQuery();
                }

            }
        }
        public static void AlterStatus(int stat, string email)
        {
            string query = "UPDATE usr SET status = @stat WHERE mail = @mail;";
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = email };
                var status = new MySqlParameter("@stat", MySqlDbType.Int32) { Value = stat };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.Parameters.Add(status);
                    int i = com.ExecuteNonQuery();
                }

            }
        }
        public static void AlterStatusAuto(string email)
        {
            string query = "UPDATE usr SET status = @stat WHERE mail = @mail;";
            using (var con = new MySqlConnection(connectionString))
            {
                int stat = 1;
                if (GetStatus(email))
                {
                    stat = 0;
                }
                con.Open();
                var mail = new MySqlParameter("@mail", MySqlDbType.VarChar) { Value = email };
                var status = new MySqlParameter("@stat", MySqlDbType.Int32) { Value = stat };

                using (var com = new MySqlCommand(query, con))
                {
                    com.Parameters.Add(mail);
                    com.Parameters.Add(status);
                    int i = com.ExecuteNonQuery();
                }

            }
        }
    }
}
