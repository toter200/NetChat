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

namespace Avalonia.NETCoreApp
{
    public class MainWindow : Window
    {
        public User localUser;
        private StackPanel chatWindow;
        private ObservableCollection<Message> currentChat;
        
        public MainWindow()
        {
            InitializeComponent();
            currentChat.CollectionChanged += ChatChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            chatWindow = this.FindControl<StackPanel>("chatWindow");
            
            User us1 = new User("random mail", 1, IPAddress.Parse("192.168.0.103"));
            localUser = new User("hajduk.d01@htl-ottakring.ac.at", 0, IPAddress.Parse("192.168.0.102"));
            Chat ch = new Chat(localUser, us1);
            Message msg1 = new Message("first message", 0);
            Message msg2 = new Message("seccond message", 1);
            localUser.SendMessage(msg1, ch);
            us1.SendMessage(msg2, ch);
            
            ShowChat(chatWindow, ch);
        }

        private void ShowChat(StackPanel window, Chat chat)
        {
            currentChat = new ObservableCollection<Message>(chat.msgList);
            foreach (Message msg in chat.msgList)
            {
                TextBlock tb = new TextBlock();
                if (msg.UserId == localUser.Id)
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
            TextBox tbox = this.FindControl<TextBox>("MessageInput");
            Message msg = new Message(tbox.Text, localUser.Id);
            currentChat.Add(msg);
        }
        private void ChatChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (Message msg in e.NewItems)
            {
                TextBlock tb = new TextBlock();
                if (msg.UserId == localUser.Id)
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
        
    }
}