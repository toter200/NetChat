using System;
using System.Runtime.Serialization;

namespace NCSharedlib
{
    /// <summary>
    /// Wrapper for text messages
    /// </summary>
    [DataContract]
    public class Message
    {
        
        /// <summary>
        /// Content of the Message = text
        /// </summary>
        [DataMember]
        public string Content { get; private set; }
        
        /// <summary>
        /// Sender of the messafe
        /// </summary>
        [DataMember]
        public User MessageOwner { get; private set; }
        
        /// <summary>
        /// Time the message was send
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; private set; }
        
        /// <summary>
        /// Flag to check if message is Synchronized between devices or not
        /// </summary>
        [DataMember]
        public bool Synchronized { get; private set; }

        [DataMember]
        public string Alignment { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Content of Message</param>
        /// <param name="user">Sender of the Message</param>
        public Message(string text, User user, string alignemt)
        {
            this.Content = text;
            this.MessageOwner = user;
            this.Alignment = alignemt.ToUpper();
            Timestamp = DateTime.Now;
        }

        /*
         * TODO:
         * Correct message to recieve a assign a usr upon creation
         */
        /// <summary>
        /// Set the synchronized flag to True
        /// </summary>
        public void IsSynchronized()
        {
            this.Synchronized = true;
        }
        
        /// <summary>
        /// Comandline compatible output
        /// </summary>
        /// <returns>Content, timstamp and synchronized flag</returns>
        public override string ToString()
        {
            return Content + "- at: " + Timestamp + " Synched: " + Synchronized;
        }
    }
}