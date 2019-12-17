using System;
using System.Collections.Generic;
using System.Linq;
namespace NCSharedlib
{
    public class Chat
    {
        
        public User Reciever { get; private set; }

        public List<Message> msgList { get; private set; }

        public Chat(User u2)
        {
            this.Reciever = u2;
            msgList = new List<Message>();
        }

        public void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x=>x.Timestamp);
        }

        public void Print()
        {
            msgList.Sort();
            foreach (Message msg in msgList)
            {
                System.Console.WriteLine(msg);
            }
        }


    }
}