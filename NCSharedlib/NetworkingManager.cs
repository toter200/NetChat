using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCSharedlib
{
    public class NetworkingManager
    {

        private IClientNetwork reciever;
        public NetworkingManager(IClientNetwork msgReciever)
        {
            reciever = msgReciever;
        }
        public void StartTcpListenerThread(IPAddress ip, int port)
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
                        if (new byte[1024] != bytes)
                        {
                            Message msg = new Message(Encoding.UTF8.GetString(bytes), 1);
                            reciever.MsgRecieved(msg);
                        }
                    }
                    catch
                    {
                        throw;
                    }
            });
            tcpListenerThread.Start();
        }
        
        public static void SendMessage(string text, IPAddress ip, int port)
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


    }
    
    
}