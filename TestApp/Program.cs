﻿using System;
using System.Net;
using NCSharedlib;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User localUser = new User("hajduk.d01@htl-ottakring.ac.at", 0, IPAddress.Parse("192.168.43.228"));
            User remoteUser = new User("new@mail.com", 1, IPAddress.Parse("192.168.43.172"));
            Chat localChat = new Chat(localUser, remoteUser);
            Helper help = new Helper();
            NetworkingManager netManager = new NetworkingManager(help);
            netManager.StartTcpListenerThread(IPAddress.Parse("192.168.43.228"), User.port);
            localUser.SendMessage(new Message("test", 0), localChat);
            
        }
    }
}