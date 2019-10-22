using System;
using NetChatServerLibrary;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = DatabaseConnection.GetConnectionString();
            DatabaseConnection.ConnectToData(connectionString);
        }
    }
}
