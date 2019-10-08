using System;
using System.Threading;
namespace NetChat.console1
{
    class Program
    {
        static void Main(string[] args)
        {
            User daniel = new User("test@mail.com", 1);
            User kevin = new User("test@mail2.com", 2);

            Chat danielKevin = new Chat(daniel, kevin);

            Message daniel1 = new Message("Daniel: test message one", daniel.Id);
            Thread.Sleep(1000);
            Message daniel2 = new Message("Daniel: test message two", daniel.Id);
            Thread.Sleep(1000);
            Message kevin1 = new Message("kevin: test message one", kevin.Id);
            Thread.Sleep(1000);
            Message daniel3 = new Message("Daniel: test message three", daniel.Id);
            Thread.Sleep(1000);
            Message kevin2 = new Message("Kevin: test message two", kevin.Id);
            Thread.Sleep(1000);

            danielKevin.Add(daniel1);
            danielKevin.Add(daniel2);
            danielKevin.Add(kevin1);
            danielKevin.Add(daniel3);
            danielKevin.Add(kevin2);
            System.Console.WriteLine("FIRST CHAT UNSYNCED");
            danielKevin.print();
            System.Console.WriteLine();

            Chat danielKevinPhone = new Chat(daniel, kevin);
            System.Console.WriteLine("SECCOND CHAT UNSYNCED");
            danielKevinPhone.print();
            daniel.Sync(danielKevin, danielKevinPhone);


            System.Console.WriteLine("SECCOND CHAT SYNCED");
            danielKevinPhone.print();
        }
    }
}
