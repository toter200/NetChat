using System;
using NCSharedlib;

namespace TestApp
{
    public class Helper : IClientNetwork
    {
        public Message MsgRecieved(Message obj)
        {
            Console.WriteLine(obj.Content);
            return obj;
        }
    }
}