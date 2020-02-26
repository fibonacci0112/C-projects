using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public static int PORT = 1337;
        private TcpClient client;
        private StreamWriter stw;
        private StreamReader str;
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
        }

        public void Connect(IPAddress adresse, int port)
        {
            try
            {
                IPEndPoint IpEnd = new IPEndPoint(adresse, port);
                client.Connect(IpEnd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            stw = new StreamWriter(client.GetStream());
            str = new StreamReader(client.GetStream());


            thread = new Thread(Empfangen);
            thread.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (client.Connected)
            {
                stw.WriteLine(textBox1.Text);
                stw.Flush();
            }
        }

        public void Empfangen()
        {
            while (true)
            {

                string empfangen = str.ReadLine();
                try
                {
                    if (client.Connected)
                    {
                        label1.Text = empfangen;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: " + ex.Message.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Connect(IPAddress.Parse("127.0.0.1"), PORT);
        }
    }
}
