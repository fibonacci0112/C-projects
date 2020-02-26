using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace game
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        private int punkte = 0;
        public int Punkte {get { return punkte; }set { punkte = value; }}
        private int fehler = 0;
        public int Fehler {get { return fehler; }set { fehler = value; }}
        private bool falsch = false;
        private int sekunden = 60;
        private int milli = 0;
        private SoundPlayer wavPlayer = new SoundPlayer();
        private int eingabe = 0;

        public Form1()
        {
            KeyDown += Form1_KeyDown;
            InitializeComponent();
            pictureBox1.BackColor = Color.Black;
            pictureBox2.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox4.BackColor = Color.Black;
            pictureBox5.BackColor = Color.Black;
            pictureBox6.BackColor = Color.Black;
            pictureBox7.BackColor = Color.Black;
            pictureBox8.BackColor = Color.Black;
            pictureBox9.BackColor = Color.Black;
            pictureBox10.BackColor = Color.Black;
            label1.Text = "Punkte:";
            label2.Text = Convert.ToString(punkte);
            label3.Text = "Fehler:";
            label4.Text = Convert.ToString(fehler);
            label5.Text = "";
            wavPlayer.SoundLocation = "D:/blip.wav";
            wavPlayer.LoadCompleted += new AsyncCompletedEventHandler(wavPlayer_LoadCompleted);
            timer1.Stop();
            NächstesFeld(0);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                timer1.Start();
            }

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (pictureBox1.BackColor == Color.Red)
                        {
                            pictureBox1.BackColor = Color.Black;
                            eingabe = 1;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    case Keys.Left:
                        if (pictureBox2.BackColor == Color.Red)
                        {
                            pictureBox2.BackColor = Color.Black;
                            eingabe = 2;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    case Keys.Right:
                        if (pictureBox3.BackColor == Color.Red)
                        {
                            pictureBox3.BackColor = Color.Black;
                            eingabe = 3;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }
                        break;

                    case Keys.Down:
                        if (pictureBox4.BackColor == Color.Red)
                        {
                            pictureBox4.BackColor = Color.Black;
                            eingabe = 4;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }
                        break;

                    case Keys.W:
                        if (pictureBox6.BackColor == Color.Red)
                        {
                            pictureBox6.BackColor = Color.Black;
                            eingabe = 5;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    case Keys.A:
                        if (pictureBox7.BackColor == Color.Red)
                        {
                            pictureBox7.BackColor = Color.Black;
                            eingabe = 6;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    case Keys.D:
                        if (pictureBox8.BackColor == Color.Red)
                        {
                            pictureBox8.BackColor = Color.Black;
                            eingabe = 7;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    case Keys.S:
                        if (pictureBox9.BackColor == Color.Red)
                        {
                            pictureBox9.BackColor = Color.Black;
                            eingabe = 8;
                            Eingabe(eingabe);
                        }
                        else
                        {
                            FehlerPassiert();
                        }

                        break;

                    default:
                        break;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            milli--;

            if (milli < 0)
            {
                sekunden--;
                milli = 9;
            }

            if (falsch)
            {
                pictureBox5.BackColor = Color.Black;
                pictureBox10.BackColor = Color.Black;
                falsch = false;
            }

            
            if (sekunden < 0)
            {
                Übergabedaten.üpunkte = punkte;
                Übergabedaten.üfelher = fehler;
                Close();
            }
            else
            {
                label5.Text = string.Format("{0:00}.{1:00}", sekunden, milli);
            }
        }

        private void wavPlayer_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ((System.Media.SoundPlayer)sender).Play();
        }

        private void Eingabe(int eingabe)
        {
            NächstesFeld(eingabe);
            punkte++;
            label2.Text = Convert.ToString(punkte);
            //wavPlayer.LoadAsync();
        }

        private void NächstesFeld(int nichtDieZahl)
        {
            int nerv = 0;
            do
            {
                nerv = r.Next(1, 9);

            } while (nerv == nichtDieZahl);


            switch (nerv)
            {
                case 1:
                    pictureBox1.BackColor = Color.Red;
                    break;
                case 2:
                    pictureBox2.BackColor = Color.Red;
                    break;
                case 3:
                    pictureBox3.BackColor = Color.Red;
                    break;
                case 4:
                    pictureBox4.BackColor = Color.Red;
                    break;
                case 5:
                    pictureBox6.BackColor = Color.Red;
                    break;
                case 6:
                    pictureBox7.BackColor = Color.Red;
                    break;
                case 7:
                    pictureBox8.BackColor = Color.Red;
                    break;
                case 8:
                    pictureBox9.BackColor = Color.Red;
                    break;

                default:
                    break;
            }
        }

        public void FehlerPassiert()
        {
            fehler++;
            label4.Text = Convert.ToString(fehler);
            sekunden--;
            pictureBox5.BackColor = Color.Red;
            pictureBox10.BackColor = Color.Red;
            falsch = true;
            wavPlayer.SoundLocation = "D:/pipebang.wav";
            wavPlayer.LoadCompleted += new AsyncCompletedEventHandler(wavPlayer_LoadCompleted);
            //wavPlayer.LoadAsync();
            wavPlayer.SoundLocation = "D:/blip.wav";
        }
    }
}
