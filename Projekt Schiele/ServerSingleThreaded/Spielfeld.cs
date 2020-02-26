using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerSingleThreaded
{
    class Spielfeld
    {
        private int[,] feld;
        private string felddaten;
        public static string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                Spielfeld.name = value;
                felddaten = System.IO.File.ReadAllText("..\\..\\..\\data\\fielddata\\" + name + ".txt");
            }
        }

        public int[,] Feld
        {
            get { return feld; }
            set { feld = value; }
        }

        public Spielfeld(string name)
        {
            feld = new int[20, 20];
            felddaten = System.IO.File.ReadAllText("..\\..\\..\\data\\fielddata\\" + name + ".txt");
            int zähler = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {

                    if (felddaten.Substring(zähler, 1) == string.Empty)
                    {
                        Console.WriteLine("Fehler beim einlesen");
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
    }
}

