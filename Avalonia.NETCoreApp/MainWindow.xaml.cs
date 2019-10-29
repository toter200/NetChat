using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NCSharedlib;


/*TODO:
 create method to display chat messages;
 Fix the layout of elements in the GUI;
 Use the network manager and test if messages are recieved*/

namespace Avalonia.NETCoreApp
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
            
            User us1 = new User("random mail", 1);
            Chat ch = new Chat(us1);
            Message msg1 = new Message("first message", 1);
            Message msg2 = new Message("seccond message", 2);
            ch.Add(msg1);
            ch.Add(msg2);
            
            //Button b = new Button();
            //b.Content = "new Button";
            //mainCanvas.Children.Add(b);
            
            //ShowChat(chatWindow, ch);
        }

        private void ShowChat(StackPanel window, Chat chat)
        {
            window.HorizontalAlignment = HorizontalAlignment.Center;
            int padding = 0;
            foreach (Message msg in chat.msgList)
            {
                TextBlock tb = new TextBlock();
                tb.Text = msg.Content;
                window.Children.Add(tb);
                //canvas.Children.Add(tb);
                //t += new Thickness(0, 20, 0, 0);
            }
        }
    }
}