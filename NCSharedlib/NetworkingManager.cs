using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCSharedlib
{
    /// <summary>
    ///     Manager fall all Network related things
    /// </summary>
    public class NetworkingManager
    {
        /// <summary>
        ///     Interface for recieving new messages
        /// </summary>
        private IClientNetwork reciever;

        /// <summary>
        /// </summary>
        /// <param name="msgReciever">Class with implemented reciever interface</param>
        public NetworkingManager(IClientNetwork msgReciever)
        {
            reciever = msgReciever;
        }

        /// <summary>
        ///     Thread for listening to a port in the local ip address
        /// </summary>
        /// <param name="ip">IP address to listen to</param>
        /// <param name="port">Port to listen to</param>
        public void StartTcpListenerThread(IPAddress ip, int port)
        {
            var listener = new TcpListener(ip, port);
            listener.Start();

            var thread = new Thread(() =>
            {
                var bytes = new byte[1024];
                while (true)
                {
                    var client = listener.AcceptSocket();

                    var size = client.Receive(bytes);
                    //reciever.MsgRecieved(new Message(Encoding.UTF8.GetString(bytes, 0, size), 1));
                    client.Close();
                }
            });
            thread.Start();
        }

        /// <summary>
        ///     Send message to a remote address by tcp
        /// </summary>
        /// <param name="text">string to send</param>
        /// <param name="ip">remote ip address</param>
        /// <param name="port">remote port</param>
        public static void SendMessage(string text, IPAddress ip, int port, int flag)
        {
            text = flag + ";" + text;

            var remote = new IPEndPoint(ip, port);
            var tcpClient = new TcpClient();
            /*tcpClient.Connect(remote);
            tcpClient.Client.Send(Encoding.UTF8.GetBytes(text));
            tcpClient.Client.Close();*/
            tcpClient.Close();
        }

        /// <summary>
        ///     Get the current local ip address
        /// </summary>
        /// <param name="type">interface type </param>
        /// <returns>return the IPaddress as a IPAddress object</returns>
        public static IPAddress GetIpAddress()
        {
            var externalip = new WebClient().DownloadString("http://icanhazip.com");
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

        //TODO:
        //Finish communication with Server
        public static User GetUser(string mail)
        {
            var server = new IPEndPoint(GlobalVars.Serverip, GlobalVars.Port);
            SendMessage(mail, GlobalVars.Serverip, GlobalVars.Port, 3);

            var tcpListener = new TcpClient();
            byte[] bytes = { };
            var buffer = new byte[4096];
            bytes = Encoding.UTF8.GetBytes("3;" + mail + ";");
            tcpListener.Connect(server);
            tcpListener.Client.Send(bytes);
            var index = tcpListener.Client.Receive(buffer);
            var msg = Encoding.UTF8.GetString(buffer, 0, index);
            var msgArray = msg.Split(';');

            return new User(msgArray[1], IPAddress.Parse(msgArray[3]));
        }
    }
}