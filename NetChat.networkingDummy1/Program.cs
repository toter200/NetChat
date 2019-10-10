using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetChat.networkingDummy1
{
    internal class Program
    {
        public static readonly int Port = 20000;

        private static void Main(string[] args)
        {
            StartTcpListenerThread();
            Thread.Sleep(300);
            SendMessage("sample text");
            Console.ReadKey();
        }

        private static void StartTcpListenerThread()
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, Port);
            tcpListener.Start();
            var tcpListenerThread = new Thread(() =>
            {
                while (true)
                    try
                    {
                        var bytes = new byte[1024];
                        var currentConnection = tcpListener.AcceptTcpClient();
                        var stream = currentConnection.GetStream();
                        //Console.WriteLine(Encoding.UTF8.GetString(stream.Read(bytes, 0, bytes.Length)));
                        var numBytesReadFromStream = stream.Read(bytes, 0, bytes.Length);
                        Console.WriteLine("new message>");
                        Console.WriteLine(Encoding.UTF8.GetString(bytes));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            });
            tcpListenerThread.Start();
        }

        private static void SendMessage(string text)
        {
            var tcpSendingThread = new Thread(() =>
            {
                var tcpClient = new TcpClient("localhost", Port);

                tcpClient.Client.Send(
                    Encoding.UTF8.GetBytes(text)
                );
            });
            tcpSendingThread.Start();
        }
    }
}