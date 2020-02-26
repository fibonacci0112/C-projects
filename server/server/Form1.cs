using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace server
{

    public partial class Form1 : Form
    {
        private TcpClient client;
        private StreamWriter stw;
        private StreamReader str;

        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
            this.Show();
            textBox2.Text = "127.0.0.1";
        }

        private void Connect()
        {
            try
            {
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(textBox2.Text), 1);
                client.Connect(IpEnd);
                if (client.Connected)
                {
                    MessageBox.Show("hat sich mit Server verbunden");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            stw = new StreamWriter(client.GetStream());
            str = new StreamReader(client.GetStream());
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();

        }

        private void Senden(string text)
        {
            if (client.Connected)
            {
                stw.WriteLine(text);
                stw.Flush();
            }
        }

        private void Empfangen()
        {
            string empfangen = str.ReadLine();
            try
            {
                if (client.Connected)
                {
                    if (empfangen.StartsWith("xxbutton"))
                     {
                         string feld = empfangen.Substring(8);
                         switch (feld)
                         {
                             case "3":
                                 button3.Text = "X";
                                 break;
                             case "4":
                                 button4.Text = "X";
                                 break;
                             case "5":
                                 button5.Text = "X";
                                 break;
                             case "6":
                                 button6.Text = "X";
                                 break;
                             case "7":
                                 button7.Text = "X";
                                 break;
                             case "8":
                                 button8.Text = "X";
                                 break;
                             case "9":
                                 button9.Text = "X";
                                 break;
                             case "10":
                                 button10.Text = "X";
                                 break;
                             case "11":
                                 button11.Text = "X";
                                 break;
                             default:
                                 break;
                         }
                     }
                     else
                     {

                    richTextBox1.AppendText("\n" + empfangen);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Senden(textBox1.Text);
            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Empfangen();
            System.Threading.Thread.Sleep(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "")
            {
                button3.Text = "O";
                Senden("xxbutton3");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "")
            {
                button4.Text = "O";
                Senden("xxbutton4");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "")
            {
                button5.Text = "O";
                Senden("xxbutton5");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "")
            {
                button6.Text = "O";
                Senden("xxbutton6");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "")
            {
                button7.Text = "O";
                Senden("xxbutton7");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "")
            {
                button8.Text = "O";
                Senden("xxbutton8");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "")
            {
                button9.Text = "O";
                Senden("xxbutton9");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "")
            {
                button10.Text = "O";
                Senden("xxbutton10");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "")
            {
                button11.Text = "O";
                Senden("xxbutton11");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private bool HatGewonnen()
        {
            if (button3.Text == "O" && button4.Text == "O" && button5.Text == "O" || button3.Text == "O" && button6.Text == "O" && button9.Text == "O" || button6.Text == "O" && button7.Text == "O" && button8.Text == "O" || button4.Text == "O" && button7.Text == "O" && button10.Text == "O" || button9.Text == "O" && button10.Text == "O" && button11.Text == "O" || button5.Text == "O" && button8.Text == "O" && button11.Text == "O" || button3.Text == "O" && button7.Text == "O" && button11.Text == "O" || button5.Text == "O" && button7.Text == "O" && button9.Text == "O")
            {
                richTextBox1.AppendText("Client gewinnt!");
                Senden("Client Gewinnt");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Unentschieden()
        {
            if (button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "" && button10.Text != "" && button11.Text != "")
            {
                richTextBox1.AppendText("Unentschieden!");
                Senden("Unentschieden!");
            }
        }

    }
}
