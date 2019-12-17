using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net;

namespace ServerLibrary
{
    public class Clientmanager : IClientNetwork
    {

        public string MsgRecieved(object obj)
        {
            string stringObject = obj.ToString();
            stringObject = stringObject.Substring(0, stringObject.IndexOf('\0'));
            string[] stringArray = stringObject.Split(';');
            string mail = stringArray[1];
            string username = stringArray[2];
            string ipString = stringArray[3];

            switch (stringArray[0])
            {
                case "0":
                    ServerManager.CreateUser(ipString, username, mail);
                    return null;

                case "1":
                    ServerManager.AlterIp(ipString, mail);
                    return null;

                case "2":
                    if (ServerManager.GetStatus(mail))
                    {
                        return ("2;" + "True");
                    }
                    else
                    {
                        return ("2;" + "False");
                    }

                case "3":
                    return ("3;" + ServerManager.GetAll(mail));

                case "4":
                    ServerManager.AlterStatusAuto(mail);
                    return null;

                case "7":
                    ServerManager.CreateNewDevice(ipString, mail);
                    return null;

                default:
                    return null;
            }
        }
    }
}
