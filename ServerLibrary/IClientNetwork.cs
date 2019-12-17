using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServerLibrary
{
    /// <summary>
    /// Interface for receiving messages
    /// </summary>
    public interface IClientNetwork
    {
        /// <summary>
        /// Process a recievec Message
        /// </summary>
        /// <param name="obj">new Message object</param>
        /// <returns>Processed message object</returns>
        string MsgRecieved(object obj);
    }
}
