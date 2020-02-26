using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiebBerechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int anfangsbetrag = 0;
            int rechbetrag = anfangsbetrag;
            int uhrzeit = 8;
            int zähler = 0;

            while (true)
            {
                if (rechbetrag < 0)
                {
                    Console.WriteLine(rechbetrag);
                }
                if (rechbetrag % 5 == 0 && zähler == 4)
                {
                    rechbetrag = rechbetrag * 4 / 5;
                    Console.WriteLine("endbetrag: " + anfangsbetrag);
                    Console.WriteLine("zahler: {0}", zähler);
                    Console.WriteLine("uhrzeit: {0}", uhrzeit);
                    Console.ReadKey();
                }
                if ((rechbetrag - uhrzeit) % 5 == 0)
                {
                    rechbetrag -= uhrzeit;
                    rechbetrag = rechbetrag *4/ 5;
                    uhrzeit++;
                    zähler++;
                    
                }
                else
                {
                    zähler = 0;
                    uhrzeit = 8;
                    anfangsbetrag++;
                    rechbetrag = anfangsbetrag;
                }
            }
        }
    }
}

