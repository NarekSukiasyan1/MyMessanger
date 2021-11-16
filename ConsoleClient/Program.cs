using System;
using Newtonsoft.Json;
namespace MyMessanger {
    class Program {
        static void Main(string[] args) {
            Message msg = new Message("Admin","Hello Me",DateTime.Now);
            Console.WriteLine(msg);
            String output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message newmsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(newmsg);
        }
    }
}
