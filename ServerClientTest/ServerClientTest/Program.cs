using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerClientTest
{
    class Program
    {
        public static int PORT = 1337;
        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            List<Client> clients = new List<Client>();


            while (clients.Count < 1)
            {
                Console.WriteLine("Warte auf Client " + (clients.Count+1));
                TcpClient c = server.AcceptTcpClient();
                clients.Add(new Client(c));
            }

            while (true)
            {
                string text = Console.ReadLine();
                foreach (Client c in clients)
                {
                    c.Senden(text);
                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
