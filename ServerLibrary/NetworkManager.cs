﻿using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace ServerLibrary
{
    /// <summary>
    /// Manager fall all Network related things
    /// </summary>
    public class NetworkingManager
    {
        /// <summary>
        /// Interface for recieving new messages
        /// </summary>
        private IClientNetwork reciever;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgReciever">Class with implemented reciever interface</param>
        public NetworkingManager(IClientNetwork msgReciever)
        {
            reciever = msgReciever;
        }
        /// <summary>
        /// Thread for listening to a port in the local ip address
        /// </summary>
        /// <param name="ip">IP address to listen to</param>
        /// <param name="port">Port to listen to</param>
        public void StartTcpListenerThread(IPAddress ip, int port)
        {
            Console.WriteLine("Start the Listener");
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            Console.WriteLine("Listener Started");
            var thread = new Thread(() =>
            {
                while (true)
                {

                    TcpClient client = listener.AcceptTcpClient();
                    byte[] bytes = new byte[client.ReceiveBufferSize];

                    // IPEndPoint remoteIpEndPoint = client.RemoteEndPoint as IPEndPoint;
                    // string ipAddress = remoteIpEndPoint.Address.ToString();
                    Console.WriteLine("Receive");
                    using (var stream = client.GetStream())
                    {
                        stream.Read(bytes, 0, client.ReceiveBufferSize);
                    }
                    string receivedText = Encoding.UTF8.GetString(bytes);
                    reciever.MsgRecieved(receivedText, ip, port);
                    client.Close();
                }
            });
            thread.Start();
        }

        /// <summary>
        /// Send message to a remote address by tcp
        /// </summary>
        /// <param name="text">string to send</param>
        /// <param name="ip">remote ip address</param>
        /// <param name="port">remote port</param>
        public static void SendMessage(string text, IPAddress ip, int port)
        {


            IPEndPoint remote = new IPEndPoint(ip, port);
            var tcpClient = new TcpClient();
            tcpClient.Connect(remote);
            tcpClient.Client.Send(Encoding.UTF8.GetBytes(text));
            tcpClient.Client.Close();
            tcpClient.Close();
        }

        /// <summary>
        /// Get the current local ip address
        /// </summary>
        /// <param name="type">interface type </param>
        /// <returns>return the IPaddress as a IPAddress object</returns>
        public static IPAddress GetIpAddress(NetworkInterfaceType type)
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            return IPAddress.Parse(externalip.Trim());
            /*
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
            */
        }
    }
}
