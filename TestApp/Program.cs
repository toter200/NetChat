using System;
using System.Net;
using NCSharedlib;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User localUser = new User("testUser", "hajduk.d01@htl-ottakring.ac.at", 1 , IPAddress.Parse("192.168.137.252"));
            User remoteUser = new User("remoteUser", "remote@htl-ottakring.ac.at", 2 , IPAddress.Parse("192.168.137.252"));
            localUser.NewChat(remoteUser);
            
            MemoryManager.WriteToFile(localUser);
            User readUser= MemoryManager.ReadFormFile();
            Console.WriteLine(readUser);

            Console.WriteLine(readUser.mail);
            Console.WriteLine(readUser.Chats[0].localUser.mail);
            Console.WriteLine(readUser.Chats[0].Reciever.mail);
            //string externalip = new WebClient().DownloadString("http://icanhazip.com");        
            //Console.WriteLine(externalip);
        }
    }
}