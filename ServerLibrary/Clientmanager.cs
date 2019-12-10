using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;

namespace ServerLibrary
{
    public class Clientmanager : IClientNetwork
    {

        public void MsgRecieved(object obj, IPAddress ip, int port)
        {
            string stringObject = obj.ToString();
            stringObject = stringObject.Substring(0, stringObject.IndexOf('\0'));
            string[] stringArray = stringObject.Split(';');
            string mail = stringArray[1];
            string username = stringArray[2];
            string ipString = ip.ToString();

            switch (stringArray[0])
            {
                case "0":
                    ServerManager.CreateUser(ipString, username, mail);
                    break;

                case "1":
                    ServerManager.AlterIp(ipString, ipString);
                    break;

                case "2":
                    if (ServerManager.GetStatus(mail))
                    {
                        NetworkingManager.SendMessage("True", ip, port);
                    }
                    else
                    {
                        NetworkingManager.SendMessage("False", ip, port);
                    }
                    break;

                case "3":
                    NetworkingManager.SendMessage(ServerManager.GetUser(mail), ip, port);
                    break;

                case "4":
                    ServerManager.AlterStatusAuto(mail);
                    break;

                case "7":
                    ServerManager.CreateNewDevice(ipString, mail);
                        break;

                default:
                    break;
            }


        }
    }
}
