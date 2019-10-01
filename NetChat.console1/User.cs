using System;
using System.Collections.Generic;
namespace NetChat.console1
{
    public class User
    {
        public string mail { get; private set; }
        public int Id { get; private set; }

        public User(string mail, int id)
        {
            this.mail = mail;
            this.Id = id;
        }

        public void SendMessage(Message text, Chat chat)
        {
            chat.Add(text);
        }

        public void Sync(Chat chat1, Chat chat2)
        {
            List<Message> unsynched = new List<Message>();
            foreach (Message msg in chat1.msgList)
            {
                if (!msg.Synchronized)
                {
                    unsynched.Add(msg);
                }
            }
            foreach (Message msg in unsynched)
            {
                chat2.Add(msg);
            }
            
            unsynched = new List<Message>();
            foreach (Message msg in chat2.msgList)
            {
                if (!msg.Synchronized)
                {
                    unsynched.Add(msg);
                }
            }
            foreach (Message msg in unsynched)
            {
                chat1.Add(msg);
            }
        }
    }
}