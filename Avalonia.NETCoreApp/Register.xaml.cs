using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NCSharedlib;

namespace Avalonia.NETCoreApp
{
    public class Register : Window
    {
        public Register()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnButtonSend(object sender, EventArgs e)
        {
            var mail = this.FindControl<TextBox>("mailBox").Text;
            var localUser = new User(mail, NetworkingManager.GetIpAddress());
            MemoryManager.WriteToFile(localUser);
            //NetworkingManager.SendMessage(mail, GlobalVars.Serverip, GlobalVars.Port, 0);
            Close();
        }
    }
}