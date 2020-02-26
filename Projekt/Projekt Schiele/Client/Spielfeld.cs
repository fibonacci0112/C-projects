using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    class Spielfeld
    {
        private int[,] feld;
        private string felddaten;


        public Spielfeld(string feldname)
        {
            feld = new int[20, 20];
            felddaten = System.IO.File.ReadAllText("..\\..\\..\\data\\fielddata\\"+ feldname +".txt");
            int zähler = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {

                    if (felddaten.Substring((i * j), 1) == string.Empty)
                    {
                        MessageBox.Show("Fehler beim einlesen");
                        feld[j, i] = 0;
                    }
                    else
                    {
                        feld[j, i] = Int32.Parse(felddaten.Substring(zähler, 1));
                    }
                    zähler++;
                }
            }
        }

        public int[,] Feld
        {
            get { return feld; }
            set { feld = value; }
        }
    }
}
