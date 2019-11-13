using System;

namespace NCSharedlib
{
    /// <summary>
    /// Wrapper for text messages
    /// </summary>
    public class Message
    {
        
        /// <summary>
        /// Content of the Message = text
        /// </summary>
        public string Content { get; private set; }
        
        /// <summary>
        /// Sender of the messafe
        /// </summary>
        public User MessageOwner { get; private set; }
        
        /// <summary>
        /// Time the message was send
        /// </summary>
        public DateTime Timestamp { get; private set; }
        
        /// <summary>
        /// Flag to check if message is Synchronized between devices or not
        /// </summary>
        public bool Synchronized { get; private set; }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Content of Message</param>
        /// <param name="user">Sender of the Message</param>
        public Message(string text, User user)
        {
            this.Content = text;
            this.MessageOwner = user;
            Timestamp = DateTime.Now;
        }
        
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