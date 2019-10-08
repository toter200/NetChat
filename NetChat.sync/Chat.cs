using System;
using System.Collections.Generic;
using System.Linq;
namespace NetChat.console1
{
    public class Chat
    {
        public User User1 { get; private set; }
        public User User2 { get; private set; }

        public List<Message> msgList { get; private set; }

        public Chat(User u1, User u2)
        {
            this.User1 = u1;
            this.User2 = u2;
            msgList = new List<Message>();
        }

        public void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x=>x.Timestamp);
        }

        public void print()
        {
            foreach (Message msg in msgList)
            {
                System.Console.WriteLine(msg);
            }
        }


    }
}