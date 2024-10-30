using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgrammingC.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serverBuilder = new ServerBuilder();

            
            Action<string> messageHandler = (message) =>
            {
                Console.WriteLine($"Received: {message}");

                
                serverBuilder.SendMessage($"Echo: {message}");
            };

            serverBuilder.Run(messageHandler);

            Console.WriteLine("Server has been shut down.");
        }
    }
}
