using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stellplatz> liste = new List<Stellplatz>();


            liste.Add(new LaVille(true, 1, 14, 21, true));
            liste.Add(new Eau(true,2, 13, 21, true));
            liste.Add(new LaVille(false, 3, 12, 21, false));
            liste.Add(new Eau(false, 4, 11, 21, false));

            foreach (Stellplatz i in liste)
            {
                Console.WriteLine(i.ToString());
            }
            StellplatzSorter sps = new StellplatzSorter();

            for (int j = 0; j < liste.Count; j++)
            {
                for (int i = 0; i < liste.Count-1; i++)
                {
                    if (sps.Compare(liste[i], liste[i + 1]) == 1)
                    {
                        Stellplatz s = liste[i];
                        liste[i] = liste[i + 1];
                        liste[i + 1] = s;
                    }
                }
            }

            foreach (Stellplatz i in liste)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine(Umrechnen(8));
        }

        public static int Umrechnen(int zahl)
        {
            int ergebnis = 0;
            int rechnung = 0;
            int stelle = 1;

            while (zahl>7)
            {
                rechnung = zahl % 7;
                ergebnis +=rechnung * stelle;
                zahl /= 7;
                stelle *= 10;
            }
            ergebnis += zahl * stelle;

            return ergebnis;
        }
    }
}
