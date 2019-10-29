using System;
using System.Collections.Generic;
using System.Net;

namespace NCSharedlib
{
    public class User
    {
        public string mail { get; private set; }
        public int Id { get; private set; }
        public IPAddress ip;
        public static int port = 48000;
        public List<Chat> Chats;

        private static int IdCounter;
        

        //Think the devices throught, adding a new chat for every device doesnt make sense.
        //Every device will have multiple chats...
        /*public User(string mail, int id)
        {
            this.mail = mail;
            this.Id = id;
            this.Chats = new List<Chat>();
        }*/

        public User(string mail,int id, IPAddress ip)
        {
            this.mail = mail;
            this.Id = id;
            this.ip = ip;
        }
        
        
        public User(string mail, IPAddress ip)
        {
            this.mail = mail;
            IdCounter++;
            this.Id = IdCounter;
            this.ip = ip;
        }

        public void NewChat(Chat chat)
        {
            Chats.Add(chat);
        }

        public void SendMessage(Message text, Chat chat)
        {
            chat.Add(text);
        }
        
        public void Sync(Chat chat1, Message msg)
        {
            chat1.Add(msg);
            chat1.msgList.Sort();
        }
        public void Sync(Message msg)
        {
            var user = msg.UserId;

            foreach (var chat in Chats)
            {
                if (chat.Reciever.Id == user)
                {
                    this.SendMessage(msg, chat);
                }
            }
            //OLD SYNC Method, still here because im not sure if anyone will need it
            /*List<Message> unsynched = new List<Message>();
            foreach (Message msg in chat1.msgList)
            {
                if (!msg.Synchronized)
                {
                    msg.IsSynchronized();
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
                    msg.IsSynchronized();
                    unsynched.Add(msg);
                }
            }
            foreach (Message msg in unsynched)
            {
                chat1.Add(msg);
            }*/
        }
    }
}