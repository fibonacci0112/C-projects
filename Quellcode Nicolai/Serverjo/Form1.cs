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

namespace Serverjo
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private StreamWriter stw;
        private StreamReader str;

        public Form1()
        {
            InitializeComponent();
        }

        private void Starten()
        {
            TcpListener tcpl = new TcpListener(IPAddress.Any, 1);
            tcpl.Start();
            client = tcpl.AcceptTcpClient();
            //MessageBox.Show("hat sich verbunden");
            stw = new StreamWriter(client.GetStream());
            str = new StreamReader(client.GetStream());
            backgroundWorker1.DoWork +=new DoWorkEventHandler(backgroundWorker1_DoWork);
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

        public delegate void ÄndereButtonDelegate(Button btn, string text);

        void ÄndereButton(Button btn, string text)
        {
            btn.Text = text;
        }

        private void ButtonEmpfangen(string feld)
        {
            switch (feld)
            {
                case "3":
                    button3.Invoke(new ÄndereButtonDelegate(ÄndereButton), button3, "O");
                    break;
                case "4":
                    button4.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button4, "X" });
                    break;
                case "5":
                    button5.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button5, "X" });
                    break;
                case "6":
                    button6.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button6, "X" });
                    break;
                case "7":
                    button7.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button7, "X" });
                    break;
                case "8":
                    button8.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button8, "X" });
                    break;
                case "9":
                    button9.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button9, "X" });
                    break;
                case "10":
                    button10.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button10, "X" });
                    break;
                case "11":
                    button11.Invoke(new ÄndereButtonDelegate(ÄndereButton), new object[] { button11, "X" });
                    break;
                default:
                    break;
            }
            //Control.BeginInvoke(
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
                        ButtonEmpfangen(feld);
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
            Starten();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Backgroundworker startet");
            while (true)
            {
                Empfangen();
                System.Threading.Thread.Sleep(200);
            }
            //Console.WriteLine("Backgroundworker ende");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "")
            {
                button3.Text = "X";
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
                button4.Text = "X";
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
                button5.Text = "X";
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
                button6.Text = "X";
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
                button7.Text = "X";
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
                button8.Text = "X";
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
                button9.Text = "X";
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
                button10.Text = "X";
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
                button11.Text = "X";
                Senden("xxbutton11");
            }
            if (!HatGewonnen())
            {
                Unentschieden();
            }

        }

        private bool HatGewonnen()
        {
            if (button3.Text == "X" && button4.Text == "X" && button5.Text == "X" || button3.Text == "X" && button6.Text == "X" && button9.Text == "X" || button6.Text == "X" && button7.Text == "X" && button8.Text == "X" || button4.Text == "X" && button7.Text == "X" && button10.Text == "X" || button9.Text == "X" && button10.Text == "X" && button11.Text == "X" || button5.Text == "X" && button8.Text == "X" && button11.Text == "X" || button3.Text == "X" && button7.Text == "X" && button11.Text == "X" || button5.Text == "X" && button7.Text == "X" && button9.Text == "X")
            {
                richTextBox1.AppendText("Server gewinnt!");
                Senden("Server Gewinnt");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Unentschieden()
        {
            if (button3.Text!=""&&button4.Text!=""&&button5.Text!=""&&button6.Text!=""&&button7.Text!=""&&button8.Text!=""&&button9.Text!=""&&button10.Text!=""&&button11.Text!="")
            {
                richTextBox1.AppendText("Unentschieden!");
                Senden("Unentschieden!");
            }
        }

        private void Spielerwechsel()
        {

        }
    }
}
