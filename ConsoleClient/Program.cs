using System;
using Newtonsoft.Json;
using System.Threading;
using System.Timers;
namespace MyMessanger {
    class Program {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static void GetNewMessages() {
            while (true) {
                Message msg = API.GetMessage(MessageID);
                while (msg != null) {
                    Console.WriteLine(msg);
                    MessageID++;
                    msg = API.GetMessage(MessageID);
                }
                Thread.Sleep(1000);
            }
        }
        static void Main() {
            MessageID = 0;
            Console.WriteLine("Введите Ваше имя:");
            //UserName = "RusAl";
            UserName = Console.ReadLine();
            string MessageText = "";
            Thread myThread = new Thread(new ThreadStart(GetNewMessages));
            myThread.Start(); // запускаем поток
            while (MessageText != "exit") {
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1) {
                    Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }

            }
        }
    }
}
