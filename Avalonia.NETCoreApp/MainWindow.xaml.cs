using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
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
        private StackPanel chatWindow;
        /// <summary>
        /// Messages in current chat window
        /// </summary>
        private ObservableCollection<Message> currentChat;
        /// <summary>
        /// Networking manager for current session
        /// </summary>
        private NetworkingManager netManager;

        public ObservableCollection<Tuple<Chat, Chat>> ChatCollection;

        public User us1;
        public Chat chat;
        public MainWindow()
        {
            currentChat = new ObservableCollection<Message>();
            ChatCollection = new ObservableCollection<Tuple<Chat, Chat>>();
            InitializeComponent();
            currentChat.CollectionChanged += ChatChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            var chatlist = this.FindControl<ListBox>("ChatList");
            chatlist
            /*
            us1 = new User("random mail", 1, IPAddress.Parse("192.168.43.228"));
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", 0, IPAddress.Parse("192.168.43.172"));
            chat = new Chat(localUser, us1);
            Message msg1 = new Message("first message", 0);
            Message msg2 = new Message("seccond message", 1);
            
            Dispatcher.UIThread.InvokeAsync(() => ShowChat(chatWindow, chat));
            
            //Networkingmanager initialization
            netManager = new NetworkingManager(new Clientmanager(currentChat));
            //Starting listener on the predifined Port and the current user IP
            netManager.StartTcpListenerThread(IPAddress.Parse("192.168.43.172"), User.port);
            //Saving the StackPnael control in a variable
            chatWindow = this.FindControl<StackPanel>("chatWindow");*/
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

        public void NewMessage(Message msg)
        {
            currentChat.Add(msg);
        }
        private void OnButtonSend(object sender, EventArgs e)
        {
            try
            {
                TextBox tbox = this.FindControl<TextBox>("MessageInput");
                Message msg = new Message(tbox.Text, localUser);
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
                        chatWindow.Children.Add(tb);
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