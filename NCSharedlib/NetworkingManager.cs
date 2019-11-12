using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
                        reciever.MsgRecieved(new Message(Encoding.UTF8.GetString(bytes, 0, size), 1));
                        client.Close();
                    }
                });
            thread.Start();
        }
        
        public static void SendMessage(string text, IPAddress ip, int port)
        {
            
            
            IPEndPoint remote = new IPEndPoint(ip, port);
            var tcpClient = new TcpClient();
            tcpClient.Connect(remote);
            tcpClient.Client.Send(Encoding.UTF8.GetBytes(text));
            tcpClient.Client.Close();
            tcpClient.Close();
        }

        public static IPAddress GetLocalIPAddress(NetworkInterfaceType type)
        {
            
            foreach (NetworkInterface interf in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (interf.NetworkInterfaceType == type && interf.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in interf.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address;
                        }
                    }
                }
            }
            return IPAddress.Loopback;
        }
    }
}