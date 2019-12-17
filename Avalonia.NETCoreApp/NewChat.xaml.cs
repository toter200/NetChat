using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NCSharedlib;


namespace Avalonia.NETCoreApp
{
    public class NewChat : Window
    {
        private MainWindow main;
        private User localUser;
        public NewChat(MainWindow mainwindow)
        {
            main = mainwindow;
            AvaloniaXamlLoader.Load(this);
        }

        public void OnButtonNewChat(object sender, EventArgs e)
        {
            string mail = this.FindControl<TextBox>("mailBox").Text;
            User usr = NetworkingManager.GetUser(mail);
            Chat chat = new Chat(GlobalVars.LocalUser, usr);
            main.NewChat(chat);
            this.Close();
        }
    }
}