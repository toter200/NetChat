using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NCSharedlib;
using System.Threading;
using System.Windows.Input;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Diagnostics.ViewModels;
using Avalonia.Input;
using Avalonia.Threading;
using SharpDX.DXGI;
using System.IO;


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

        public ObservableCollection<ChatList> knownChatCollection;

        public User us1;
        public Chat chat;
        public MainWindow()
        {
            currentChat = new ObservableCollection<Message>(); 
            knownChatCollection= new ObservableCollection<ChatList>();
            InitializeComponent();
            currentChat.CollectionChanged += ChatChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            
            //TODO:
            //Kerer Fragen ob die Register seite xml schreiben soll und gleich wieder Lesen
            if (!File.Exists(@"./data.xml"))
            {
                this.Hide();
                var register = new Register();
                //register.Show();
                register.ShowDialog(this);
            }
            
            localUser = MemoryManager.ReadFromFile();

            GlobalVars.LocalUser = localUser;
            
            us1 = new User("test@mail.com", IPAddress.Loopback);
            
            chat = new Chat(localUser, us1);
            Chat chat2 = new Chat(us1, localUser);
            
            ChatList list1 = new ChatList(chat, chat2);
            knownChatCollection.Add(list1);
            
            
            ListBox chatlist = this.FindControl<ListBox>("ChatList");

            chatlist.Items = knownChatCollection;

            //currentChatList.Items = currentChat
#if !DEBUG
            netManager = new NetworkingManager(new Clientmanager(currentChat));
            
            netManager.StartTcpListenerThread(IPAddress.Loopback, GlobalVars.Port);
            
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", NetworkingManager.GetIpAddress());
            us1 = new User("loopback user", IPAddress.Loopback);
            
            
            //stackPanel.Children.Add(localUser);
            
            chat = new Chat(localUser, us1);
            Chat localChat = new Chat(localUser, localUser);
            
            //Tuple<string, int> t = new Tuple<string, int>("1", 2);
            
            knownChatCollection.Add(new Tuple<Chat, Chat>(chat, localChat));
            
            ListBox chatlist = this.FindControl<ListBox>("ChatList");
            ListBox currentChatList = this.FindControl<ListBox>("currentChat");
            StackPanel wrapper = this.FindControl<StackPanel>("wrapper");
            Message msg = new Message(NetworkingManager.GetIpAddress().ToString(), localUser, "LEFT");
#endif

        }


        public void NewChat(Chat ch)
        {
            ChatList chlist = new ChatList(ch, ch);
            knownChatCollection.Add(chlist);
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