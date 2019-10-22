using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NCSharedlib;

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
            Canvas mainCanvas;
            AvaloniaXamlLoader.Load(this);
            
            
            User us1 = new User("random mail", 1);
            Chat ch = new Chat(us1);
            Message msg1 = new Message("first message", 1);
            Message msg2 = new Message("seccond message", 2);
            ch.Add(msg1);
            ch.Add(msg2);
            
            mainCanvas = this.FindControl<Canvas>("mainCanvas");
            //Button b = new Button();
            //b.Content = "new Button";
            //mainCanvas.Children.Add(b);
            
            ShowChat(mainCanvas, ch);
            
            
            
        }

        private void ShowChat(Canvas canvas, Chat chat)
        {
            Thickness t = new Thickness(0);
            
            int padding = 0;
            foreach (Message msg in chat.msgList)
            {
                
                TextBox tb = new TextBox();
                tb.Text = msg.Content;
                tb.Margin = t;
                canvas.Children.Add(tb);
                t += new Thickness(50);
            }
        }
    }
}