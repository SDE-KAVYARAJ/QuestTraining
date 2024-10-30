using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgrammingC.Client
{
    internal class ClientBuilder
    {
        private const string ipAddress = "127.0.0.1";
        private const int port = 8000;
        private TcpClient _client;
        private NetworkStream _stream;

        private void Build()
        {
            _client = new TcpClient(ipAddress, port);
            _stream = _client.GetStream();
            Console.WriteLine($"Connected to server at {ipAddress}:{port}");
        }

        public void Run(Action<string> sendMessageAction)
        {
            Build();

            while (true)
            {
                Console.Write("Enter message to send ");
                string messageToSend = Console.ReadLine();

                
                sendMessageAction(messageToSend);

                
                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {response}");
            }
            ShutDown();
        }
        public void SendMessage(string message)
        {
            byte[] dataToSend = Encoding.ASCII.GetBytes(message);
            _stream.Write(dataToSend, 0, dataToSend.Length);
            Console.WriteLine($"Sent: {message}");
        }

       
        public void ShutDown()
        {
            _stream.Close();
            _client.Close();
            Console.WriteLine("Client shut down.");
        }
    }
}
