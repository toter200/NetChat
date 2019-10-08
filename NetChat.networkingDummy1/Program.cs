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
            StartTcpSendingThread();
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

        private static void StartTcpSendingThread()
        {
            var tcpSendingThread = new Thread(() =>
            {
                var tcpClient = new TcpClient("localhost", Port);
                while (true)
                    try
                    {
                        tcpClient.Client.Send(
                            Encoding.UTF8.GetBytes("sample Text. can i make this string as long as i can?"));
                        //tcpClient.Client.Send(new byte[] {1, 2, 8});
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
            });
            tcpSendingThread.Start();
        }
    }
}