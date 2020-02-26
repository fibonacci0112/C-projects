using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ServerClientTest
{
    class Client
    {
        private TcpClient client;
        private StreamWriter stw;
        private StreamReader str;
        private Thread clThread;


        public Client(TcpClient c)
        {
            client = c;
            stw = new StreamWriter(client.GetStream());
            str = new StreamReader(client.GetStream());
            clThread = new Thread(Empfangen);
            clThread.Start();
        }

        public void Empfangen()
        {
            while (true)
            {
                try
                {
                    if (client.Connected)
                    {
                        Console.WriteLine(str.ReadLine());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }

        public void Senden(string text)
        {
            if (client.Connected)
            {
                stw.WriteLine(text);
                stw.Flush();
            }
        }
    }
}
