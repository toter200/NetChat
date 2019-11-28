using System;
using System.Net;
using NCSharedlib;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User localUser = new User("hajduk.d01@htl-ottakring.ac.at",  IPAddress.Parse("192.168.137.252"));
            User remoteUser = new User("new@mail.com", IPAddress.Parse("192.168.137.238"));
            localUser.NewChat(localUser, remoteUser);
            //MemoryManager.WriteToFile(localUser);
            //User readUser= MemoryManager.ReadFormFile();
            //Console.WriteLine(readUser);
            string externalip = new WebClient().DownloadString("http://icanhazip.com");            
            Console.WriteLine(externalip);            
        }
    }
}