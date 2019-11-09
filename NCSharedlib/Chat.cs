using System;
using System.Collections.Generic;
using System.Linq;
namespace NCSharedlib
{
    public class Chat
    {
        /// <summary>
        /// User at the other end of the Chat
        /// </summary>
        public User Reciever { get; private set; }
        /// <summary>
        /// Local User on the Device
        /// </summary>
        public User localUser { get; private set; }

        /// <summary>
        /// List of all messages
        /// </summary>
        public List<Message> msgList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localUser">Local user on current Device</param>
        /// <param name="u2">Remote user on the internet</param>
        public Chat(User localUser, User u2)
        {
            this.Reciever = u2;
            this.localUser = localUser;
            msgList = new List<Message>();
        }

        /// <summary>
        /// reciev a new message and sort it by date
        /// </summary>
        /// <param name="msg">Message object</param>
        internal void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x=>x.Timestamp);
            NetworkingManager.SendMessage(msg.Content, Reciever.ip, User.port);
        }
    }
}