using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NCSharedlib;

namespace Avalonia.NETCoreApp
{
    public class NewChat : Window
    {
        private User localUser;
        private readonly MainWindow main;

        public NewChat(MainWindow mainwindow)
        {
            main = mainwindow;
            AvaloniaXamlLoader.Load(this);
        }

        public void OnButtonNewChat(object sender, EventArgs e)
        {
            var mail = this.FindControl<TextBox>("mailBox").Text;
            var usr = new User(mail, NetworkingManager.GetIpAddress());
            //User usr = NetworkingManager.GetUser(mail);
            var chat = new Chat(GlobalVars.LocalUser, usr);
            main.NewChat(chat);
            Close();
        }
    }
}