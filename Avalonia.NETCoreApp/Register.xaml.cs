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
            string mail = this.FindControl<TextBox>("mailBox").Text;
            User localUser = new User(mail, NetworkingManager.GetIpAddress());
            MemoryManager.WriteToFile(localUser);
            #if !DEBUG
                NetworkingManager.SendMessage(mail, GlobalVars.Serverip, GlobalVars.Port, 0);
            #endif
        }
    }
}