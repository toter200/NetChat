using System.Collections.ObjectModel;
using NCSharedlib;

namespace Avalonia.NETCoreApp
{
    public class Clientmanager : IClientNetwork
    {
        private ObservableCollection<Message> msg;

        public Clientmanager(ObservableCollection<Message> msg)
        {
            this.msg = msg;
        }
        public  Message MsgRecieved(Message obj)
        {
            msg.Add(obj);
            return obj;
        }
    }
}