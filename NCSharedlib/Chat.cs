using System;
using System.Collections.Generic;
using System.Linq;
namespace NCSharedlib
{
    public class Chat
    {
        
        public User Reciever { get; private set; }
        public User localUser { get; private set; }

        public List<Message> msgList { get; private set; }

        public Chat(User localUser, User u2)
        {
            this.Reciever = u2;
            this.localUser = localUser;
            msgList = new List<Message>();
        }

        internal void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x=>x.Timestamp);
            NetworkingManager.SendMessage(msg.Content, Reciever.ip, User.port);
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