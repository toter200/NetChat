using System;

namespace NCSharedlib
{
    public class Message
    {
        public string Content { get; private set; }
        public int UserId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool Synchronized { get; private set; }

        public Message(string text, int Userid)
        {
            this.Content = text;
            this.UserId = Userid;
            Timestamp = DateTime.Now;
        }
        public void IsSynchronized()
        {
            this.Synchronized = true;
        }
        public override string ToString()
        {
            return Content + "- at: " + Timestamp + " Synched: " + Synchronized;
        }
    }
}