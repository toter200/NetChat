using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace NCSharedlib
{
    [DataContract]
    public class Chat
    {
        /// <summary>
        /// User at the other end of the Chat
        /// </summary>
        [DataMember] public List<User> Reciever;
        
        //public User Reciever { get; private set; }
        /// <summary>
        /// Local User on the Device
        /// </summary>
        [DataMember]
        public User localUser { get; set; }

        /// <summary>
        /// List of all messages
        /// </summary>
        [DataMember]
        public List<Message> msgList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localUser">Local user on current Device</param>
        /// <param name="u2">Remote user on the internet</param>
        public Chat(User localUser, User reciever)
        {
            this.Reciever = reciever;
            this.localUser = localUser;
            msgList = new List<Message>();
        }
        
        public Chat(User u2)
        {
            this.Reciever = new List<User>{ u2 };
            //this.localUser = localUser;
            this.msgList = new List<Message>();
        }

        public Chat(List<User> userlist)
        {
            this.Reciever = userlist;
        }

        /// <summary>
        /// receive a new message and sort it by date
        /// </summary>
        /// <param name="msg">Message object</param>
        internal void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x=>x.Timestamp);
            foreach (User usr in Reciever)
            {
                NetworkingManager.SendMessage(msg.Content, usr.ip, User.port, 4);
            }
        }
    }
}