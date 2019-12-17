using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Xunit;

namespace XUnitTestNetChat
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            void StartTcpListenerThread(IPAddress ip, int port)
            {
                var tcpListener = new TcpListener(ip, port);
                tcpListener.Start();
                var tcpListenerThread = new Thread(() =>
                {
                    while (true)
                        try
                        {
                            var bytes = new byte[1024];
                            var currentConnection = tcpListener.AcceptTcpClient();
                            var stream = currentConnection.GetStream();
                            stream.Read(bytes, 0, bytes.Length);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                });
                tcpListenerThread.Start();
            }

            void SendFile(IPAddress address, int port, string path)
            {
                var client = new TcpClient();
                client.Connect(new IPEndPoint(address, port));
                try
                {
                    NetworkStream networkStream = client.GetStream();
                    FileStream fileStream = File.OpenRead(path);
                    fileStream.CopyTo(networkStream);
                    fileStream.Close();
                }
                finally
                {
                    client?.Close();
                }
            }

            
        }
    }
}
