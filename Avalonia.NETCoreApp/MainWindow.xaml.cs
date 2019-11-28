using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NCSharedlib;
using System.Threading;
using Avalonia.Threading;


/*
 * TODO:
 * Create a homepage with multiple chats;
 * Figure out how to change do different chats;
 * Implement the locally saved data into the Prototype;
 * Implement Encryption into the Prototype;
 */

namespace Avalonia.NETCoreApp
{
    public class MainWindow : Window
    {
        /// <summary>
        /// Local User
        /// </summary>
        public User localUser;
        /// <summary>
        /// Main chat window in current View
        /// </summary>
        private ListBox chatWindow;
        /// <summary>
        /// Messages in current chat window
        /// </summary>
        private ObservableCollection<Message> currentChat;
        /// <summary>
        /// Networking manager for current session
        /// </summary>
        private NetworkingManager netManager;

        public ObservableCollection<Tuple<Chat, Chat>> knownChatCollection;

        public User us1;
        public Chat chat;
        public MainWindow()
        {
            currentChat = new ObservableCollection<Message>(); 
            knownChatCollection= new ObservableCollection<Tuple<Chat, Chat>>();
            InitializeComponent();
            currentChat.CollectionChanged += ChatChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
            
            netManager = new NetworkingManager(new Clientmanager(currentChat));
            
            netManager.StartTcpListenerThread(IPAddress.Loopback, User.port);
            
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", NetworkingManager.GetIpAddress(NetworkInterfaceType.Ethernet));
            us1 = new User("loopback suer", IPAddress.Parse());
            
            chat = new Chat(localUser, us1);
            
            ListBox chatlist = this.FindControl<ListBox>("ChatList");
            ListBox currentChatList = this.FindControl<ListBox>("currentChat");

            chatlist.Items = knownChatCollection;
            currentChatList.Items = currentChat;
            Message msg = new Message(NetworkingManager.GetIpAddress(NetworkInterfaceType.Ethernet).ToString(), localUser, "LEFT");
            
            //localUser.SendMessage(msg, chat);
                      
        }

        private void ShowChat(StackPanel window, Chat chat)
        {
            foreach (Message msg in chat.msgList)
            {
                TextBlock tb = new TextBlock();
                
                if (msg.MessageOwner == localUser)
                {
                    tb.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {
                    tb.HorizontalAlignment = HorizontalAlignment.Left;
                }
                tb.Text = msg.Content;
                window.Children.Add(tb);
            }
        }

        /*public void NewMessage(Message msg)
        {
            currentChat.Add(msg);
        }
        */
        private void OnButtonSend(object sender, EventArgs e)
        {
            try
            {
                TextBox tbox = this.FindControl<TextBox>("MessageInput");
                Message msg = new Message(tbox.Text, localUser, "RIGHT");
                currentChat.Add(msg);
                
                localUser.SendMessage(msg, chat);
            }
            catch
            {
                throw;
            }
        }
        private void ChatChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
                {
                    foreach (Message msg in e.NewItems)
                    {
                        TextBlock tb = new TextBlock();
                        if (msg.MessageOwner == localUser)
                        {
                            tb.HorizontalAlignment = HorizontalAlignment.Right;
                        }
                        else
                        {
                            tb.HorizontalAlignment = HorizontalAlignment.Left;
                        }

                        tb.Text = msg.Content;
                        //chatWindow.Children.Add(tb);
                    }
                }
            );
        }

        /*
         * TODO:
         * finish observable colleciton
         */
        private void ChatListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                foreach (var touple in e.NewItems)    
                {
                    
                }
            });
        }
        
    }
}