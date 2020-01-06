using System.Reactive;
using NCSharedlib;
using ReactiveUI;

namespace Avalonia.NETCoreApp
{
    public class ChatList : ReactiveObject
    {
        public Chat chat;

        public ChatList(Chat chat)
        {
            this.chat = chat;
            ClickChangeChatButton = ReactiveCommand.Create(ChangeChat);
        }

        public ReactiveCommand<Unit, Unit> ClickChangeChatButton { get; }

        public void ChangeChat()
        {
            MainWindow.currentChat.Clear();
            foreach (var msg in chat.msgList) MainWindow.currentChat.Add(msg);
            //MainWindow.currentChat = new ObservableCollection<Message>(chat.msgList);
        }
    }
}