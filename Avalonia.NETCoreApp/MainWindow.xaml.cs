using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using NCSharedlib;


/*
 * TODO:
 * Create a homepage with multiple chats;
 * Figure out how to change do different chats;
 * Implement the locally saved data into the Prototype;
 * Implement Encryption into the Prototype;
 */

namespace Avalonia.NETCoreApp
{
    public class MainWindow : Window, INewChat
    {
        /// <summary>
        ///     Messages in current chat window
        /// </summary>
        public static ObservableCollection<Message> currentChat;

        public Chat chat;

        /// <summary>
        ///     Main chat window in current View
        /// </summary>
        private ListBox chatWindow;

        public ObservableCollection<ChatList> knownChatCollection;

        /// <summary>
        ///     Local User
        /// </summary>
        public User localUser;

        /// <summary>
        ///     Networking manager for current session
        /// </summary>
        private NetworkingManager netManager;

        public User us1;

        public MainWindow()
        {
            currentChat = new ObservableCollection<Message>();
            knownChatCollection = new ObservableCollection<ChatList>();
            InitializeComponent();
            currentChat.CollectionChanged += ChatChanged;
        }


        public void NewChat(Chat ch)
        {
            var cl = new ChatList(ch);
            knownChatCollection.Add(cl);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);


            if (!File.Exists(@"./data.xml"))
            {
                Hide();
                var register = new Register();
                //register.Show();
                register.ShowDialog(this);
            }
#if DEBUG
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", NetworkingManager.GetIpAddress());
#endif
#if !DEBUG
            localUser = MemoryManager.ReadFromFile();
#endif


            GlobalVars.LocalUser = localUser;
            chatWindow = this.FindControl<ListBox>("currentChat");
            us1 = new User("test@mail.com", IPAddress.Loopback);

            chat = new Chat(localUser, us1);
            var msg = new Message("hello", us1, "LEFT");
            chat.msgList.Add(msg);
            var cl = new ChatList(chat);
            knownChatCollection.Add(cl);


            var chatlist = this.FindControl<ListBox>("ChatList");

            chatlist.Items = knownChatCollection;

            netManager = new NetworkingManager(new Clientmanager(currentChat));
            //currentChat = new ObservableCollection<Message>(chat.msgList);
            netManager.StartTcpListenerThread(IPAddress.Loopback, GlobalVars.Port);
            chatWindow.Items = currentChat;
        }

        public void OnPointerEnter(object sender, PointerEventArgs e)
        {
            var bt = (Button) sender;
            bt.Background = Brushes.Gray;
        }

        public void OnPointerLeave(object sender, PointerEventArgs e)
        {
            var bt = (Button) sender;
            bt.Background = Brushes.Black;
        }

        private void OnButtonSend(object sender, EventArgs e)
        {
            var tbox = this.FindControl<TextBox>("MessageInput");
            var msg = new Message(tbox.Text, localUser, "RIGHT");
            currentChat.Add(msg);

            localUser.SendMessage(msg, chat);
        }

        public void OnButtonNewChat(object sender, EventArgs e)
        {
            var newChatWindow = new NewChat(this);
            newChatWindow.ShowDialog(this);
        }

        public void OnButtonChat(object sender, EventArgs e)
        {
            //User us = ((Button) sender).DataContext as User;
        }

        private void ChatChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
                {
                    foreach (Message msg in e.NewItems)
                        /*TextBlock tb = new TextBlock();
                            if (msg.MessageOwner == localUser)
                            {
                                tb.HorizontalAlignment = HorizontalAlignment.Right;
                            }
                            else
                            {
                                tb.HorizontalAlignment = HorizontalAlignment.Left;
                            }
    
                            tb.Text = msg.Content;*/
                        chatWindow.Items = currentChat;
                }
            );
        }

        public void OnUserClick(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var pop = new Popup();
            var popBlock = new TextBlock();
            var type = btn.Name;
            var popstring = "";

            switch (type)
            {
                case "UserInfo":
                    popstring = "You are loged in as " + localUser.mail;
                    break;
                case "NetworkInfo":
                    popstring = "This feature is currently not implemented";
                    break;
            }

            popBlock.Text = popstring;
            popBlock.Background = Brushes.Black;
            popBlock.Foreground = Brushes.Yellow;
            pop.Child = popBlock;
            pop.IsOpen = true;
        }
    }
}