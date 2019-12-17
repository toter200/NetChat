using System.Reactive;
using NCSharedlib;
using ReactiveUI;

namespace Avalonia.NETCoreApp
{
    public class ChatList : ReactiveObject
    {
        public Chat chat1;
        public Chat chat2;

        public ChatList( Chat chat1, Chat chat2 )
        {
            this.chat1 = chat1;
            this.chat2 = chat2;
            ClickChangeChatButton = ReactiveCommand.Create(ChangeChat);
        }

        public ReactiveCommand<Unit, Unit> ClickChangeChatButton { get; }
        public void ChangeChat()
        {
            
        }
    }
}