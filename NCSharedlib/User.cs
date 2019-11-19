using System;
using System.Collections.Generic;
using System.Net;

namespace NCSharedlib
{
    public class User
    {
        /// <summary>
        /// E-mail used by User to Register
        /// </summary>
        public string mail { get; private set; }
        
        /// <summary>
        /// user id set by server
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Constantly changing ip address 
        /// </summary>
        public IPAddress ip;

        /// <summary>
        /// Username for a User
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// fixed port for communication
        /// </summary>
        public static int port = 48000;
        
        /// <summary>
        /// all hats known to User
        /// </summary>
        public List<Chat> Chats;

        
        /// <summary>
        /// Static id counter *possibly useless
        /// </summary>
        private static int IdCounter;
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail">Users mail address</param>
        /// <param name="id">Users id</param>
        /// <param name="ip">Users ip address</param>
        public User(string username, string mail,int id, IPAddress ip)
        {
            this.Name = username;
            this.mail = mail;
            this.Id = id;
            this.ip = ip;
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail">Users mail address</param>
        /// <param name="ip"> Users ip address</param>
        public User(string mail, IPAddress ip)
        {
            this.mail = mail;
            IdCounter++;
            this.Id = IdCounter;
            this.ip = ip;
        }

        
        /// <summary>
        /// Create a new Chat between Local user and remote user
        /// </summary>
        /// <param name="chat"></param>
        public void NewChat(User localUser, User remoteUser)
        {
            Chat newChat = new Chat(localUser, remoteUser);
            Chats.Add(newChat);
        }

        
        /// <summary>
        /// Send a Messache thorught to a exsting chat
        /// </summary>
        /// <param name="text">Text of message</param>
        /// <param name="chat">Chat to send to</param>
        public void SendMessage(Message text, Chat chat)
        {
            chat.Add(text);
        }
        
        /// <summary>
        /// add a older message to a chat and sort it by time
        /// </summary>
        /// <param name="chat">chat to add the message</param>
        /// <param name="msg"> Older message from another device</param>
        public void Sync(Chat chat, Message msg)
        {
            chat.Add(msg);
            chat.msgList.Sort();
        }
        
        /*
         * TODO:
         * Destinguisch between recieving Sync messages and sending,
         * and get both functions to work
         */
        public void Sync(Message msg)
        {
            var user = msg.MessageOwner;

            foreach (var chat in Chats)
            {
                if (chat.Reciever == user)
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