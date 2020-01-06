using System;
using System.Net;
using NCSharedlib;

namespace TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var localUser = new User("testUser", "hajduk.d01@htl-ottakring.ac.at", 1,
                IPAddress.Parse("192.168.137.252"));
            var remoteUser = new User("remoteUser", "remote@htl-ottakring.ac.at", 2,
                IPAddress.Parse("192.168.137.252"));
            localUser.NewChat(remoteUser);

            DotNetSerializer.WriteToFile(localUser);
            var readUser = DotNetSerializer.ReadFromFile();
            Console.WriteLine(readUser);

            Console.WriteLine(readUser.mail);
            Console.WriteLine(readUser.Chats[0].LocalUser.mail);
            Console.WriteLine(readUser.Chats[0].Reciever.mail);
            //string externalip = new WebClient().DownloadString("http://icanhazip.com");        
            //Console.WriteLine(externalip);
        }
    }
}