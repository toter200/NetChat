using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ServerLibrary
{
    class Clientmanager : IClientNetwork
    {

        public void MsgRecieved(object obj, string ip)
        {
            string stringObject = obj.ToString();
            string[] stringArray = stringObject.Split(';');
            string mail = stringArray[1];
            string unam = stringArray[2];

            switch (stringArray[0])
            {
                case "0":
                    ServerManager.CreateUser(ip , mail, unam);
                    break;
                case "1":
                    ServerManager.AlterIp(ip, mail);
                    break;
                case "2":
                    ServerManager.GetStatus(mail);
                    break;
                case "3":
                    ServerManager.GetUser(mail);
                    break;
                case "4":
                    ServerManager.AlterStatusAuto(mail);
                    break;
                case "7":
                    ServerManager.
                        break;
                default:
                    break;
            }


        }
    }
}
