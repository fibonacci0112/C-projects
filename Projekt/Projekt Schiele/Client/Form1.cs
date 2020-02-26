using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;

namespace Client
{
    public partial class Form1 : Form
    {
        private static int PORT = 1337;
        private TcpClient client;
        private StreamWriter stw;
        private StreamReader str;
        private Thread thread;
        private Process serverstarter;
        private Spielfeld spielfeld;
        private Spielfeld sfvorbewegung;
        private SoundPlayer Player;
        private string klasse = "";
        private string gegnerklasse;
        private string hilfsstring="seaside";
        private int clnummer;
        private int geld = 0;
        private int xkoord;
        private int ykoord;
        private int figurx;
        private int figury;
        string[] figurdaten;
        private int bewpnkt;


        public Form1()
        {
            InitializeComponent();
            client = new TcpClient();
            lbl_Warten.Text = "";
            FileInfo[] felder = new System.IO.DirectoryInfo("..\\..\\..\\data\\field").GetFiles();
            string[] feldernamen = new string[felder.Length];
            for (int i = 0; i < felder.Length; i++)
            {
                feldernamen[i] = Path.GetFileNameWithoutExtension(felder[i].ToString());
            }
            lstBx_Felder.Items.AddRange(feldernamen);
            txtBx_IPAdresse.Text = "127.0.0.1";

        }

        private void Menü_btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Name)
            {
                case "Beenden_btn":
                    this.Close();
                    break;

                case "zurück_Option_btn":
                case "Zurück_btn1":
                    tablessControl1.SelectTab(0);
                    break;

                case "Start_btn":
                case "Zurück_btn2_Ers":
                case "Zurück_btn3":
                    tablessControl1.SelectTab(1);
                    break;

                case "Spiel_erstellen_btn":
                    tablessControl1.SelectTab(2);
                    break;

                case "Spiel_beitreten_btn":
                    tablessControl1.SelectTab(3);
                    break;
                case "Tutorial_Zurück_btn":
                case "Optionen_btn":
                    tablessControl1.SelectTab(5);
                    break;

                case "Tutorial_btn":
                    tablessControl1.SelectTab(6);
                    break;

                default:
                    break;
            }
        
        }

        private void Spiel_Beitret_Start_btn_Click(object sender, EventArgs e)
        {
            if (klasse == "")
            {
                MessageBox.Show("bitte Klasse auswählen");
                return;
            }
            this.Connect(IPAddress.Parse(txtBx_IPAdresse.Text), PORT);
        }

        private void Spiel_Erstell_Start_btn_Click(object sender, EventArgs e)
        {

            if (klasse == "")
            {
                MessageBox.Show("bitte Klasse auswählen");
                return;
            }
            if (lstBx_Felder.SelectedItem == null)
            {
                MessageBox.Show("bitte Feld auswählen");
                return;
            }
            serverstarter = new Process();
            serverstarter.StartInfo.FileName = "..\\..\\..\\ServerSingleThreaded\\bin\\Debug\\ServerSingleThreaded.exe";
            serverstarter.Start();
            System.Threading.Thread.Sleep(100);
            this.Connect(IPAddress.Parse("127.0.0.1"), PORT);
            hilfsstring = lstBx_Felder.Text;
            lbl_Warten.Text = "Warten auf Spieler";
            Spiel_Erstell_Start_btn.Enabled = false;
            Spiel_Erstell_Start_btn.BackColor = Color.Gray;
        }

        private void Connect(IPAddress adresse, int port)
        {
            try
            {
                IPEndPoint IpEnd = new IPEndPoint(adresse, port);
                client.Connect(IpEnd);
                stw = new StreamWriter(client.GetStream());
                str = new StreamReader(client.GetStream());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
           
            thread = new Thread(Empfangen);
            thread.Start();
        }

        public string FeldAuswahl()
        {
            System.Drawing.Point position;
            position = MousePosition;
            position.X -= (4 + this.Location.X) + 5;
            position.Y -= (43 + this.Location.Y) + 5;
            position.X /= (int)Math.Round(30.0);
            position.Y /= (int)Math.Round(30.0);
            xkoord = position.X;
            ykoord = position.Y;
            return string.Concat(position.X.ToString(), ",", position.Y.ToString());
        }

        private void pB_SpielFeld_MouseClick(object sender, MouseEventArgs e)
        {
            this.Senden("feld" + this.FeldAuswahl());
        }

        public void Senden(params string[] anweisungen)
        {
            foreach (string anweisung in anweisungen)
            {
                if (client.Connected)
                {
                    stw.WriteLine(anweisung);
                    stw.Flush();
                }
            }
        }

        public void Empfangen()
        {
            while (true)
            {
                try
                {
                    if (!client.Connected)
                    {
                        break;
                    }
                    string empfangen = str.ReadLine();

                    switch (empfangen.Substring(0, 4))
                    {
                        case "klas":
                            if (empfangen.Substring(4) != "")
                            {
                                MessageBox.Show("Spieler 1 hat diese Klasse bereits gewählt. Bitte neu Wählen");
                                switch (empfangen.Substring(4))
                                {
                                    case "red":
                                        btn_Red_Bei.Enabled = false;
                                        btn_Red_Bei.BackColor = Color.Gray;
                                        break;
                                    case "green":
                                        btn_Green_Bei.Enabled = false;
                                        btn_Green_Bei.BackColor = Color.Gray;
                                        break;
                                    case "blue":
                                        btn_Blue_Bei.Enabled = false;
                                        btn_Blue_Bei.BackColor = Color.Gray;
                                        break;
                                    default:
                                        break;
                                }

                            }
                            else
                            {
                                this.Senden(klasse);
                            }
                            break;

                        case "gekl":
                            gegnerklasse = empfangen.Substring(4);
                            break;

                        case "fena":
                            spielfeld = new Spielfeld(hilfsstring);
                            sfvorbewegung = new Spielfeld(hilfsstring);
                            pB_SpielFeld.BackgroundImage = Image.FromFile("..\\..\\..\\data\\field\\" + hilfsstring + ".bmp");
                            this.Senden(hilfsstring);
                            break;

                        case "fese":
                            spielfeld = new Spielfeld(empfangen.Substring(4));
                            sfvorbewegung = new Spielfeld(empfangen.Substring(4));
                            pB_SpielFeld.BackgroundImage = Image.FromFile("..\\..\\..\\data\\field\\" + empfangen.Substring(4) + ".bmp");
                            this.Senden(klasse);
                            break;

                        case "tabw":
                            this.BeginInvoke((MethodInvoker)delegate { tablessControl1.SelectTab(4); });
                            geld = Convert.ToInt32(empfangen.Substring(5,4));
                             lbl_Geld_Anzeige.Text = geld.ToString(); ;
                            clnummer = Convert.ToInt32(empfangen.Substring(4,1));
                            bewpnkt = Convert.ToInt32(empfangen.Substring(9));
                            lbl_Punkte_Anzeige.Text = bewpnkt.ToString();
                            Senden("gekl"+klasse);
                            break;

                        case "fewe":
                            switch (empfangen.Substring(4,1))
                            {
                               
                                    
                                case "2":           //Bewegung&Angriff

                                    break;
                                case "3":           //Angriff

                                    break;
                                case "4":           //Bewegung

                                    break;
                                case "1":
                                case "5":
                                    if (btn_Level_UP.Enabled||btn_Runner.Enabled)
                                    {
                                        FeldÜberschreiben(sfvorbewegung, spielfeld);
                                        ElementeVerbergen();
                                        ArealLöschen();
                                    }
                                    
                                    break;
                                case "6":                      
                                    PlaySound("OnFigur");
                                    if (btn_Level_UP.Enabled)   // Zweiter Click auf Figur
                                    {
                                        FeldÜberschreiben(sfvorbewegung, spielfeld);
                                        ElementeVerbergen();
                                        ArealLöschen();
                                    }
                                    else                        //erster Click auf Figur
                                    {
                                        int zähler = 0;
                                        FeldÜberschreiben(spielfeld, sfvorbewegung);
                                        ElementeVerbergen();
                                        figurx = xkoord;
                                        figury = ykoord;
                                        if (clnummer == 0)
                                        {                                            
                                            for (int i = 0; i < 7; i++)
                                            {
                                                if (i + figury - 3 >= 0 && i + figury - 3 < 20)
                                                {
                                                    for (int j = 0; j < 7; j++)
                                                    {
                                                        if (j + figurx - 3 >= 0 && i + figury - 3 < 20)
                                                        {
                                                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 9 || spielfeld.Feld[j + figurx - 3, i + figury - 3] == 8) 
                                                            { spielfeld.Feld[j + figurx - 3, i + figury - 3] = 5; }
                                                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 5)
                                                            {
                                                                spielfeld.Feld[j + figurx - 3, i + figury - 3] -= Convert.ToInt32(empfangen.Substring(5).Substring(zähler, 1));
                                                            }
                                                        }
                                                        zähler++;
                                                    }
                                                }
                                                else
                                                {
                                                    zähler += 7;
                                                }
                                            }
                                            ArealZeichnen();
                                            
                                        }
                                        ElementeAnzeigen(empfangen.Substring(55).Split(','));
                                    }

                                    break;
                                case "7":
                                    PlaySound("OnFigur");
                                    if (btn_Level_UP.Enabled)   // Zweiter Click auf Figur
                                    {
                                        FeldÜberschreiben(sfvorbewegung, spielfeld);
                                        ElementeVerbergen();
                                        ArealLöschen();
                                    }
                                    else                        //erster Click auf Figur
                                    {
                                        int zähler = 0;
                                        FeldÜberschreiben(spielfeld, sfvorbewegung);
                                        ElementeVerbergen();
                                        figurx = xkoord;
                                        figury = ykoord;
                                        if (clnummer == 1)
                                        {                                            
                                            for (int i = 0; i < 7; i++)
                                            {
                                                if (i + figury - 3 >= 0 && i + figury - 3 < 20)
                                                {
                                                    for (int j = 0; j < 7; j++)
                                                    {
                                                        if (j + figurx - 3 >= 0 && i + figury - 3 < 20)
                                                        {
                                                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 9 || spielfeld.Feld[j + figurx - 3, i + figury - 3] == 8) 
                                                            { spielfeld.Feld[j + figurx - 3, i + figury - 3] = 5; }
                                                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 5)
                                                            {
                                                                spielfeld.Feld[j + figurx - 3, i + figury - 3] -= Convert.ToInt32(empfangen.Substring(5).Substring(zähler, 1));
                                                            }
                                                        }
                                                        zähler++;
                                                    }
                                                }
                                                else
                                                {
                                                    zähler += 7;
                                                }
                                            }
                                            ArealZeichnen();
                                            
                                        }
                                        ElementeAnzeigen(empfangen.Substring(55).Split(','));
                                    }

                                    break;
                                case "8":       //Spawn Client2
                                    
                                    if (btn_Level_UP.Enabled)
                                    {
                                        FeldÜberschreiben(sfvorbewegung, spielfeld);
                                        ElementeVerbergen();
                                        ArealLöschen();
                                    }
                                    if (clnummer == 1)
                                    {
                                        figurx = xkoord;
                                        figury = ykoord;
                                        ElementeAnzeigen();
                                    }

                                    break;
                                case "9":       //Spawn Client1
                                    if (btn_Level_UP.Enabled)
                                    {
                                        FeldÜberschreiben(sfvorbewegung, spielfeld);
                                        ElementeVerbergen();
                                        ArealLöschen();
                                    }
                                    if (clnummer == 0)
                                    {
                                        figurx = xkoord;
                                        figury = ykoord;
                                        ElementeAnzeigen();
                                    }
                                    break;
                            }
                            break;

                        case "neuf":
                            figurdaten = empfangen.Substring(4).Split(',');
                            if (spielfeld.Feld[Convert.ToInt32(figurdaten[6]), Convert.ToInt32(figurdaten[7])] == 9 
                                || spielfeld.Feld[Convert.ToInt32(figurdaten[6]), Convert.ToInt32(figurdaten[7])] == 8)
                            {
                                FigurZeichnen(figurdaten[0], gegnerklasse, Convert.ToInt32(figurdaten[6]), Convert.ToInt32(figurdaten[7]));
                            }
                            Senden("weit");
                            break;

                        case"weit":
                            break;

                        case"losg":
                            MessageBox.Show("Runde startet");
                            break;

                        default:
                            MessageBox.Show(empfangen);
                            break;
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show("Fehler: " + e.Message.ToString() + e.ToString());
                    Environment.Exit(1);
                }
            }
        }

        private void FeldÜberschreiben(Spielfeld von, Spielfeld nach)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    nach.Feld[j, i] = von.Feld[j, i];
                }
            }
            FeldÜbergeben(von);
        }

        private void FeldÜbergeben(Spielfeld feld)
        {
            string übergabe = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                     übergabe = übergabe.Insert(übergabe.Length,feld.Feld[j, i].ToString());
                }
            }
            Senden("feüb"+ übergabe);
        }

        private void btn_Klassenauswahl_Click(object sender, EventArgs e)
        {
            if (btn_Red_Bei.Enabled && btn_Green_Bei.Enabled && btn_Blue_Bei.Enabled)
            {
                btn_Red_Ers.BackColor = Color.Maroon;
                btn_Green_Ers.BackColor = Color.Maroon;
                btn_Blue_Ers.BackColor = Color.Maroon;
                btn_Red_Bei.BackColor = Color.Maroon;
                btn_Green_Bei.BackColor = Color.Maroon;
                btn_Blue_Bei.BackColor = Color.Maroon;
            }


            if (sender == btn_Red_Ers || sender == btn_Red_Bei)
            {
                klasse = "red";
                ((Button)sender).BackColor = Color.Red;
            }
            else if (sender == btn_Green_Ers || sender == btn_Green_Bei)
            {
                klasse = "green";
                ((Button)sender).BackColor = Color.Red;
            }
            else if (sender == btn_Blue_Ers || sender == btn_Blue_Bei)
            {
                klasse = "blue";
                ((Button)sender).BackColor = Color.Red;
            }

            if (!btn_Red_Bei.Enabled || !btn_Green_Bei.Enabled || !btn_Blue_Bei.Enabled)
            {
                tablessControl1.SelectTab(Convert.ToInt32(4));
                Senden(klasse);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverstarter != null)
            {
                serverstarter.Kill();
            }
        }

        private void btn_Figur_Erstellen_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (geld < Convert.ToInt32(b.Text)||bewpnkt<1)
            {
                MessageBox.Show("zu wenig Ressourcen");
            }
            else 
            {
                geld -= Convert.ToInt32(b.Text);
                lbl_Geld_Anzeige.Text = geld.ToString(); ;
                bewpnkt -= 2;
                lbl_Punkte_Anzeige.Text = bewpnkt.ToString();
                FigurZeichnen(b.Text,klasse,figurx,figury);

                this.Senden("neuf" + b.Text);
            }
            
            ElementeVerbergen();
        }

        private void FigurZeichnen(string art, string klasse,int x, int y)
        {
            int partei=6;
            if (klasse==gegnerklasse)
            {
                partei = 7;
            }
            Bitmap figur = new Bitmap("..\\..\\..\\data\\graphics\\" + klasse + art +".bmp");
            Graphics grafik = Graphics.FromImage(figur);
            grafik = pB_SpielFeld.CreateGraphics();
            grafik.DrawImage(figur, (x * 30), (y * 30));
            spielfeld.Feld[x, y] = partei;
            PlaySound("Spawn");
        }

        private void ArealZeichnen()
        {
            Bitmap angriff =  new Bitmap("..\\..\\..\\data\\graphics\\angriff.bmp");
            Bitmap bewegung = new Bitmap("..\\..\\..\\data\\graphics\\bewegung.bmp");
            Graphics grafik1 = Graphics.FromImage(angriff);
            Graphics grafik2 = Graphics.FromImage(bewegung);
            grafik1 = pB_SpielFeld.CreateGraphics();
            grafik2 = pB_SpielFeld.CreateGraphics();
            for (int i = 0; i < 7; i++)
            {
                if (i + figury - 3 >= 0 && i + figury - 3 < 20)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (j + figurx - 3 >= 0 && i + figury - 3 < 20)
                        {
                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 3 || spielfeld.Feld[j + figurx - 3, i + figury - 3] == 2)
                            {
                                grafik1.DrawImage(angriff, ((j + figurx - 3) * 30), ((i + figury - 3) * 30));
                            }
                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 4)
                            {
                                grafik2.DrawImage(bewegung, ((j + figurx - 3) * 30), ((i + figury - 3) * 30));
                            }
                        }
                    }
                }
            }
        }

        public void ArealLöschen()
        {
            Bitmap feld = new Bitmap("..\\..\\..\\data\\graphics\\grasfeld.bmp");
            Bitmap spawn = new Bitmap("..\\..\\..\\data\\graphics\\spawnfeld.bmp");
            Graphics grafik1 = Graphics.FromImage(feld);
            Graphics grafik2 = Graphics.FromImage(spawn);
            grafik1 = pB_SpielFeld.CreateGraphics();
            grafik2 = pB_SpielFeld.CreateGraphics();
            for (int i = 0; i < 7; i++)
            {
                if (i + figury - 3 >= 0 && i + figury - 3 < 20)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (j + figurx - 3 >= 0 && i + figury - 3 < 20)
                        {
                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 9 || spielfeld.Feld[j + figurx - 3, i + figury - 3] == 8)
                            {
                                grafik2.DrawImage(spawn, ((j + figurx - 3) * 30), ((i + figury - 3) * 30));
                            }
                            if (spielfeld.Feld[j + figurx - 3, i + figury - 3] == 5)
                            {
                                grafik1.DrawImage(feld, ((j + figurx - 3) * 30), ((i + figury - 3) * 30));
                            }
                        }
                    }
                }
            }
        }

        public void ElementeAnzeigen(string[] figurdaten)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lbl_Angrst.Visible = true; lbl_Angrst_Anzeige.Visible = true; lbl_Art.Visible = true; lbl_Art_Anzeige.Visible = true; lbl_HP.Visible = true;
                lbl_HP_Anzeige.Visible = true; lbl_Level.Visible = true; lbl_Level_Preis.Visible = true; lbl_Vertst.Visible = true; lbl_Vertst_Anzeige.Visible = true;
                btn_Level_UP.Visible = true; btn_Level_UP.Enabled = true;
                lbl_Art_Anzeige.Text = figurdaten[0]; lbl_HP_Anzeige.Text = figurdaten[1]; lbl_Angrst_Anzeige.Text = figurdaten[2];
                lbl_Vertst_Anzeige.Text = figurdaten[3]; lbl_Level_Preis.Text = (Convert.ToInt32(figurdaten[4]) * 100).ToString();
            });
        }

        public void ElementeAnzeigen()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btn_Runner.Visible = true; btn_Soldier.Visible = true; btn_Tank.Visible = true;
                btn_Runner.Enabled = true; btn_Soldier.Enabled = true; btn_Tank.Enabled = true;
                lbl_Runner.Visible = true; lbl_Soldier.Visible = true; lbl_Tank.Visible = true;
                lbl_Runner.Enabled = true; lbl_Soldier.Enabled = true; lbl_Tank.Enabled = true;
            });

        }
        
        private void ElementeVerbergen()
        {
            if (btn_Level_UP.Enabled)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lbl_Angrst.Visible = false; lbl_Angrst_Anzeige.Visible = false; lbl_Art.Visible = false; lbl_Art_Anzeige.Visible = false; lbl_HP.Visible = false;
                    lbl_HP_Anzeige.Visible = false; lbl_Level.Visible = false; lbl_Level_Preis.Visible = false; lbl_Vertst.Visible = false; lbl_Vertst_Anzeige.Visible = false;
                    btn_Level_UP.Visible = false; btn_Level_UP.Enabled = false;
                });
            }
            else if (lbl_Runner.Visible)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btn_Runner.Visible = false; btn_Soldier.Visible = false; btn_Tank.Visible = false;
                    btn_Runner.Enabled = false; btn_Soldier.Enabled = false; btn_Tank.Enabled = false;
                    lbl_Runner.Visible = false; lbl_Soldier.Visible = false; lbl_Tank.Visible = false;
                    lbl_Runner.Enabled = false; lbl_Soldier.Enabled = false; lbl_Tank.Enabled = false;
                });
            }
        }
       
        public void PlaySound(string welchersound)
        {
            if (cbx_Sound.Checked)
            {
                Player = new System.Media.SoundPlayer();
                Player.SoundLocation = "..\\..\\..\\data\\Sounds\\" + welchersound + ".wav";
                Player.LoadAsync();
                Player.Play(); 
            }
        }

        private void btn_Runde_Beenden_Click(object sender, EventArgs e)
        {
            DialogResult antwort = MessageBox.Show("Wollen Sie die Runde beenden?", "Runde beenden", MessageBoxButtons.YesNo);

            if (antwort==DialogResult.Yes)
            {
                Senden("rube");
            }
        }
    }
}
