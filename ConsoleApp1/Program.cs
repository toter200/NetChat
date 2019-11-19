using System;

namespace NCServerLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string mail1 = "haumer.k00@htl-ottakring.ac.at";
            string mail2 = "hajduk.d01@htl-ottakring.ac.at";
            string user1 = "meikev3";
            string user2 = "toter200";


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
            Console.WriteLine();

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

            Console.WriteLine();
            ServerManager.AlterIp("3.4.5.6", mail1);
            Console.WriteLine($"IP of {user1} " + ServerManager.GetIp(mail1));
            ServerManager.AlterIp("1.1.1.1", mail1);
            Console.WriteLine($"IP of {user1} " + ServerManager.GetIp(mail1));
            ServerManager.AlterIp("3.4.5.6", mail2);
            Console.WriteLine($"IP of {user2} " + ServerManager.GetIp(mail2));
            ServerManager.AlterIp("2.2.2.2", mail2);
            Console.WriteLine($"IP of {user2} " + ServerManager.GetIp(mail2));

            Console.WriteLine();
            ServerManager.AlterStatus(0, mail1);
            Console.WriteLine($"Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatus(1, mail1);
            Console.WriteLine($"Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatus(0, mail2);
            Console.WriteLine($"Status of {user2}: " + ServerManager.GetStatus(mail2));
            ServerManager.AlterStatus(1, mail2);
            Console.WriteLine($"Status of {user2}: " + ServerManager.GetStatus(mail2));

            Console.WriteLine();
            ServerManager.AlterStatusAuto(mail1);
            Console.WriteLine($"Auto Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatusAuto(mail1);
            Console.WriteLine($"Auto Status of {user1}: " + ServerManager.GetStatus(mail1));
            ServerManager.AlterStatusAuto(mail2);
            Console.WriteLine($"Auto Status of {user2}: " + ServerManager.GetStatus(mail2));
            ServerManager.AlterStatusAuto(mail2);
            Console.WriteLine($"Auto Status of {user2}: " + ServerManager.GetStatus(mail2));

            Console.WriteLine();
            ServerManager.AlterUsername("meiekv1", mail1);
            Console.WriteLine($"Username of {user1}: " + ServerManager.GetUser(mail1));
            ServerManager.AlterUsername("meiekv3", mail1);
            Console.WriteLine($"Username of {user1}: " + ServerManager.GetUser(mail1));
            ServerManager.AlterUsername("toter1", mail2);
            Console.WriteLine($"Username of {user2}: " + ServerManager.GetUser(mail2));
            ServerManager.AlterUsername("toter200", mail2);
            Console.WriteLine($"Username of {user2}: " + ServerManager.GetUser(mail2));

            Console.WriteLine();
            Console.WriteLine("---Creating new User---");
            Console.WriteLine();
            ServerManager.CreateUser("172.0.0.1", "User2", "user2@mail.at");
            Console.WriteLine($"username of the new User: " + ServerManager.GetUser("user2@mail.at"));
            Console.WriteLine($"IP of the new User: " + ServerManager.GetIp("user2@mail.at"));
            Console.WriteLine($"Status of the new User: " + ServerManager.GetStatus("user2@mail.at"));
            Console.WriteLine($"Email of the new User: " + ServerManager.GetEmail("user2"));


            Console.WriteLine();
            Console.WriteLine("---Delete User---");
            Console.WriteLine();
            ServerManager.DeleteUser("user2@mail.at");
            Console.WriteLine("User deleted");
        }
    }
}
