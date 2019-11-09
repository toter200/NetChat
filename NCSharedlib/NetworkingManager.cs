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
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();


                
                var thread = new Thread(() =>
                {
                    byte[] bytes = new byte[1024];
                    while (true)
                    {

                        Socket client = listener.AcceptSocket();

                        int size = client.Receive(bytes);
                        reciever.MsgRecieved(new Message(Encoding.UTF8.GetString(bytes), 1));
                        client.Close();
                    }
                });
            thread.Start();
            /*tcpListener = new TcpListener(ip, port);
            tcpListener.Start();
            tcpListener.AcceptSocket();
            while (true)
            {
                var client = tcpListener.AcceptSocket();
                
                var tcpListenerThread = new Thread(() =>
                {
                    byte[] data = new byte[1024];
                    int size = client.Receive(data);
                    for (int i = 0; i < size; i++)
                    {
                        reciever.MsgRecieved(new Message(Convert.ToChar(data[i]).ToString(), 1));
                    }
                });
                client.Close();
                tcpListenerThread.Start();
            }
            
            /*var tcpListenerThread = new Thread(() =>
            {
                while (true)
                    try
                    {
                        var bytes = new byte[1024];
                        var currentConnection = tcpListener.AcceptTcpClient();
                        tcpListener.AcceptSocket();
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
            tcpListenerThread.Start();*/
            
        }
        
        public static void SendMessage(string text, IPAddress ip, int port)
        {
            
            
            IPEndPoint remote = new IPEndPoint(ip, port);
            var tcpClient = new TcpClient();
            tcpClient.Connect(remote);
            tcpClient.Client.Send(Encoding.UTF8.GetBytes("text"));
            tcpClient.Client.Close();
            tcpClient.Close();
            //tcpClient.Client.Send(Encoding.UTF8.GetBytes(text));
            /*var tcpSendingThread = new Thread(() =>
            {
                var tcpClient = new TcpClient(remote);
                tcpClient.Connect(remote);
                tcpClient.Client.Send(
                    Encoding.UTF8.GetBytes(text)
                );
            });
            tcpSendingThread.Start();*/
        }


    }
    
    
}