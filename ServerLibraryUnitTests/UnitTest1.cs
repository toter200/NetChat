using NUnit.Framework;
using ServerLibrary;
using System;
using System.Net;

namespace Tests
{
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();

            #region inputString 0-7
            string inputString0 = "0;email1;user1";
            string inputString1 = "1;email1;user1";
            string inputString2 = "2;email1;user1";
            string inputString3 = "3;email1;user1";
            string inputString4 = "4;email1;user1";
            string inputString5 = "5;email1;user1";
            string inputString6 = "6;email1;user1";
            string inputString7 = "7;email1;user1";
            #endregion

            NetworkingManager net = new NetworkingManager(new Clientmanager());
            net.StartTcpListenerThread(IPAddress.Loopback, 48000);

            #region SendMessage 1-7
            ServerLibrary.NetworkingManager.SendMessage(inputString0, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString1, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString2, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString3, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString4, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString5, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString6, IPAddress.Loopback, 48000);
            ServerLibrary.NetworkingManager.SendMessage(inputString7, IPAddress.Loopback, 48000);
            #endregion

            Console.WriteLine();
            Console.ReadKey();
        }

    }
}