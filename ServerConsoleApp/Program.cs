using System;
using ServerLibrary;
using System.Net;
using System.Net.Sockets;

namespace ServerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkingManager netManager = new NetworkingManager(new Clientmanager());
            netManager.StartTcpListenerThread(IPAddress.Parse("5.189.139.146"), 48000);
        }
    }
}
