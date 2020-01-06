using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NCSharedlib
{
    [DataContract]
    public class Chat
    {
        /// <summary>
        ///     User at the other end of the Chat
        /// </summary>
        [DataMember] public List<User> Reciever;

        /// <summary>
        /// </summary>
        /// <param name="localUser">Local user on current Device</param>
        /// <param name="u2">Remote user on the internet</param>
        public Chat(User localUser, User reciever)
        {
            Reciever = new List<User>();
            Reciever.Add(reciever);
            LocalUser = localUser;
            msgList = new List<Message>();
        }

        /*public Chat(User u2)
        {
            this.Reciever = new List<User>{ u2 };
            this.localUser = localUser;
            this.msgList = new List<Message>();
        }*/

        public Chat(User localUser, List<User> userlist)
        {
            LocalUser = localUser;
            Reciever = userlist;
        }

        //public User Reciever { get; private set; }
        /// <summary>
        ///     Local User on the Device
        /// </summary>
        [DataMember]
        public User LocalUser { get; set; }

        /// <summary>
        ///     List of all messages
        /// </summary>
        [DataMember]
        public List<Message> msgList { get; private set; }

        public string Recievers
        {
            get
            {
                var output = "";
                foreach (var user in Reciever) output += user.mail;
                return output;
            }
        }


        public string GetName()
        {
            return Reciever[0].mail;
        }

        /// <summary>
        ///     receive a new message and sort it by date
        /// </summary>
        /// <param name="msg">Message object</param>
        internal void Add(Message msg)
        {
            msgList.Add(msg);
            msgList.OrderBy(x => x.Timestamp);
            foreach (var usr in Reciever) NetworkingManager.SendMessage(msg.Content, usr.ip, GlobalVars.Port, 4);
        }
    }
}