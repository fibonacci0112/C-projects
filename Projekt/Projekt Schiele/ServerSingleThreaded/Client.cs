using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerSingleThreaded
{
    class Client
    {
        private TcpClient client;
        private StreamWriter stw;
        public StreamReader str;
        private string clNummer = String.Empty;
        private Spieler spieler;

        public string ClNummer
        {
            get { return clNummer; }
        }
        internal Spieler Spieler
        {
            get { return spieler; }
            set { spieler = value; }
        }

        public TcpClient tcp
        {
            get { return client; }
            set { client = value; }
        }

        public StreamReader Str
        {
            get { return str; }
            set { str = value; }
        }

        public Client(TcpClient c, string nummer)
        {
            client = c;
            stw = new StreamWriter(client.GetStream());
            str = new StreamReader(client.GetStream());
            spieler = new Spieler();
            this.clNummer = nummer;
        }

        public void Senden(string text)
        {
            if (client.Connected)
            {
                stw.WriteLine(text);
                stw.Flush();
            }
        }

        public void Senden(int[,] array)
        {
            if (client.Connected)
            {
                stw.WriteLine(array);
                stw.Flush();
            }
        }

    }
}
