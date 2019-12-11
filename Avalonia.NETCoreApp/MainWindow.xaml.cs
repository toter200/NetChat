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
using Avalonia.Threading;
using SharpDX.DXGI;


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

            /*StackPanel stackPanel = this.FindControl<StackPanel>("stck");
            
            
            var template = new FuncDataTemplate<User>(x =>
                new Button
                {
                    [!Button.ContentProperty] = new Binding("mail")
                });

            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.DataTemplates.Add(template);*/
            //localUser = MemoryManager.ReadFromFile();

            #region LiveTesting

            netManager = new NetworkingManager(new Clientmanager(currentChat));
            
            netManager.StartTcpListenerThread(IPAddress.Loopback, User.port);
            
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", NetworkingManager.GetIpAddress(NetworkInterfaceType.Ethernet));
            us1 = new User("loopback user", IPAddress.Loopback);
            
            
            //stackPanel.Children.Add(localUser);
            
            chat = new Chat(localUser, us1);
            Chat localChat = new Chat(localUser, localUser);
            
            //Tuple<string, int> t = new Tuple<string, int>("1", 2);
            
            knownChatCollection.Add(new Tuple<Chat, Chat>(chat, localChat));
            
            ListBox chatlist = this.FindControl<ListBox>("ChatList");
            ListBox currentChatList = this.FindControl<ListBox>("currentChat");

            chatlist.Items = knownChatCollection;
            currentChatList.Items = currentChat;
            Message msg = new Message(NetworkingManager.GetIpAddress(NetworkInterfaceType.Ethernet).ToString(), localUser, "LEFT");
            
            

            #endregion
            
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

    public class MainWindowViewModel : ViewModelBase
    {
        public void test(User ussr)
        {
            Debug.WriteLine(ussr.mail);
        }
    }
}