namespace NCSharedlib
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
        Message MsgRecieved(Message obj);
    }
}
