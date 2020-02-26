using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int b = 0;
            int ergebnis = 0;
            int ergebnisspeicher = 0;




            for (int zahl = 1; zahl <= 25000; zahl++)
            {
                ergebnis++;
                b++;
                int a = r.Next(1, 7);
                if (a == 6 && ergebnis > ergebnisspeicher)
                {
                    ergebnisspeicher = ergebnis;
                    ergebnis = 0;
                }

            }
            Console.WriteLine(ergebnisspeicher);

        }
    }
}
