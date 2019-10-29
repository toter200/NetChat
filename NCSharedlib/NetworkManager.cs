using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NetChat.NCSharedlib;

namespace NCSharedlib
{
    public static class NetworkingManager
    {
        private static void StartTcpListenerThread(IPAddress ip, int port)
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
        
        private static void SendMessage(string text, IPAddress ip, int port)
        {
            IPEndPoint remote = new IPEndPoint(ip, port);
            var tcpSendingThread = new Thread(() =>
            {
                var tcpClient = new TcpClient(remote);

                tcpClient.Client.Send(
                    Encoding.UTF8.GetBytes(text)
                );
            });
            tcpSendingThread.Start();
        }

        private static void ReadFile(string path)
        {
            const int bufsize = 8192;

            var buffer = new byte[bufsize];
            NetworkStream ns = socket.GetStream();

            using (var s = File.OpenRead(path))
            {
                int actuallyRead;
                while ((actuallyRead = s.Read(buffer, 0, bufsize)) > 0)
                {
                    ns.Write(buffer, 0, actuallyRead);
                }
            }
            ns.Flush();
        }

        private static void SendFile(IPAddress address, int port, data imageToSend)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(address, port);
                NetworkStream stream = client.GetStream();
                MessageData data = new MessageData(imageToSend);

                IFormatter formatter = new BinaryFormatter();
                while (true)
                {
                    formatter.Serialize(stream, data);
                    Thread.Sleep(1000);
                    data.GetNewImage();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
    
    
}