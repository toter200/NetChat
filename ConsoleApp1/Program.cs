using System;

namespace NCServerLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            #region inputs
            string mail1 = "haumer.k00@htl-ottakring.ac.at";
            string mail2 = "hajduk.d01@htl-ottakring.ac.at";
            string user1 = "meikev3";
            string user2 = "toter200";
            string ip1 = "172.0.0.1";
            string ip2 = "192.172.0.1";

            string aip1 = "172.255.255.1";
            string aip2 = "192.172.255.1";
            #endregion
            #region Create Database
            ServerManager.CreateDatabase();
            #endregion
            #region Create User
            Console.WriteLine();
            Console.WriteLine("---Creating new Users---");
            Console.WriteLine();
            ServerManager.CreateUser(ip1, user1, mail1);
            Console.WriteLine($"username of the new User: " + ServerManager.GetUser(mail1));
            Console.WriteLine($"IP of the new User: " + ServerManager.GetIp(mail1));
            Console.WriteLine($"Status of the new User: " + ServerManager.GetStatus(mail1));
            Console.WriteLine($"Email of the new User: " + ServerManager.GetEmail(mail1));

            Console.WriteLine();
            ServerManager.CreateUser(ip2, user2, mail2);
            Console.WriteLine($"username of the new User: " + ServerManager.GetUser(mail2));
            Console.WriteLine($"IP of the new User: " + ServerManager.GetIp(mail2));
            Console.WriteLine($"Status of the new User: " + ServerManager.GetStatus(mail2));
            Console.WriteLine($"Email of the new User: " + ServerManager.GetEmail(mail2));
            #endregion
            #region Get functions
            Console.WriteLine();
            Console.WriteLine("---Get funktions---");
            Console.WriteLine();
            Console.WriteLine(ServerManager.GetStatus(mail1));
            Console.WriteLine(ServerManager.GetStatus(mail2));
            Console.WriteLine(ServerManager.GetIp(mail1));
            Console.WriteLine(ServerManager.GetIp(mail2));
            Console.WriteLine(ServerManager.GetEmail(user1));
            Console.WriteLine(ServerManager.GetEmail(user2));
            Console.WriteLine(ServerManager.GetUser(mail1));
            Console.WriteLine(ServerManager.GetUser(mail2));
            Console.WriteLine("--- Get Status of Device");
            Console.WriteLine(ServerManager.GetStatusOfDevice(ip1));
            Console.WriteLine(ServerManager.GetStatusOfDevice(ip2));
            Console.WriteLine();
            #endregion
            #region Alter Email
            Console.WriteLine("---Alter table functions---");
            Console.WriteLine();
            ServerManager.AlterEmail("NewMail", user1);
            Console.WriteLine($"Email of {user1} " + ServerManager.GetEmail(user1));
            ServerManager.AlterEmail(mail1, user1);
            Console.WriteLine($"Email of {user1} " + ServerManager.GetEmail(user1));
            ServerManager.AlterEmail("NewMail", user2);
            Console.WriteLine($"Email of {user2} " + ServerManager.GetEmail(user2));
            ServerManager.AlterEmail(mail2, user2);
            Console.WriteLine($"Email of {user2} " + ServerManager.GetEmail(user2));
            #endregion
            #region AlterIp
            Console.WriteLine();
            ServerManager.AlterIp(aip1, mail1);
            Console.WriteLine($"IP of {user1} " + ServerManager.GetIp(mail1));
            ServerManager.AlterIp(ip1, mail1);
            Console.WriteLine($"IP of {user1} " + ServerManager.GetIp(mail1));
            ServerManager.AlterIp(aip2, mail2);
            Console.WriteLine($"IP of {user2} " + ServerManager.GetIp(mail2));
            ServerManager.AlterIp(ip2, mail2);
            Console.WriteLine($"IP of {user2} " + ServerManager.GetIp(mail2));
            #endregion
            #region AlterStatus
            Console.WriteLine();
            ServerManager.AlterStatus(0, ip1);
            Console.WriteLine($"Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatus(1, ip1);
            Console.WriteLine($"Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatus(0, ip2);
            Console.WriteLine($"Status of {user2}: " + ServerManager.GetStatus(mail2));
            ServerManager.AlterStatus(1, ip2);
            Console.WriteLine($"Status of {user2}: " + ServerManager.GetStatus(mail2));
            #endregion
            #region AlterStatusAuto
            Console.WriteLine();
            ServerManager.AlterStatusAuto(ip1);
            Console.WriteLine($"Auto Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatusAuto(ip1);
            Console.WriteLine($"Auto Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatusAuto(ip2);
            Console.WriteLine($"Auto Status of {user2}: " + ServerManager.GetStatus(mail2));
            ServerManager.AlterStatusAuto(ip2);
            Console.WriteLine($"Auto Status of {user2}: " + ServerManager.GetStatus(mail2));
            #endregion
            #region AlterUsername
            Console.WriteLine();
            ServerManager.AlterUsername("meiekv1", mail1);
            Console.WriteLine($"Username of {user1}: " + ServerManager.GetUser(mail1));
            ServerManager.AlterUsername("meiekv3", mail1);
            Console.WriteLine($"Username of {user1}: " + ServerManager.GetUser(mail1));
            ServerManager.AlterUsername("toter1", mail2);
            Console.WriteLine($"Username of {user2}: " + ServerManager.GetUser(mail2));
            ServerManager.AlterUsername("toter200", mail2);
            Console.WriteLine($"Username of {user2}: " + ServerManager.GetUser(mail2));
            #endregion
            #region CreateNewDevice
            Console.WriteLine();
            Console.WriteLine("--- Add new Device ---");
            ServerManager.CreateNewDevice("3.3.3.3", mail1);
            Console.WriteLine(ServerManager.GetIp(mail1));
            Console.WriteLine();
            #endregion
            #region Delete User
            Console.WriteLine();
            Console.WriteLine("---Delete User---");
            Console.WriteLine();
            ServerManager.DeleteUser(mail1);
            ServerManager.DeleteUser(mail2);
            Console.WriteLine("User deleted");
            Console.WriteLine();
            #endregion
            #region Delete Database
            // Console.WriteLine("Deleting Database...");
            // ServerManager.DeleteDatabase();
            #endregion
        }
    }
}
