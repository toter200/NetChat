using System.Collections.Generic;

namespace NCSharedlib
{
    public class SerilizedUser 
    {
        public string Name { get; private set; }

        public string Mail { get; private set; }

        public string IpAddress { get; private set; }

        public List<Chat> Chats { get; private set; }

        public int Id { get; private set; }

        public SerilizedUser( string name, string mail, string ip, List<Chat> chats, int id)
        {
            this.Chats = chats;
            this.Name = name;
            this.Id = id;
            this.IpAddress = ip;
            this.Mail = mail;
        }
    }
}