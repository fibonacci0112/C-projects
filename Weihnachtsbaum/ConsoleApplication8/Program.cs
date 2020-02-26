using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Weihnachtsbaum:
            //insgesamt 10 Durchläufe, also 10 reihen an "Ästen". Für das weitere Verständnis nenne ich die Schleife einfach mal "Astdurchlauf"
            for (int i = 1; i < 11; i = i + 1)
            {
                //Hier werden die Bindestriche gemacht. Beim ersten "Astdurchlauf" ergibt 11-i dann 11-1=10 Dann wird also ein - gemacht. Beim zweiten mal dann schon 11-2, also nur 9. Usw...Das macht man mit j-- weil es ja immer weniger werden.
                //Wichtig sind hier Console.Write, da mit writeleine breaks gemacht werden.
                for (int j = 11 - i; j > 1; j--)
                {
                    Console.Write("-");
                }
                //Hier kommen dann die # dazu. Im ersten"Astdurchlauf" 11-i*2=9. Um k<10 zu erfüllen kann es also nur 1x mehr durchlaufen. Beim zweiten mal dann: 11-2*2=7. Also schon 3x.
                for (int k = 11 - i * 2; k < 10; k++)
                {
                    Console.Write("#");
                }
                //Diese Schleife macht die Bindestriche auf der rechten Seite.(Nur als Zusatz)
                for (int j = 11 - i; j > 1; j--)
                {
                    Console.Write("-");
                }
                //Hier dann ein Write mit Line um "Enter" zu "drücken"
                Console.WriteLine("");

            }
            //Ganz am Ende dann noch der Stamm, relativ einfach, 3 Durchläufe, # mit Leerzeichen. Einfach ausprobieren.
            for (int x = 1; x < 4; x++)
                Console.WriteLine("--------###--------");
            Console.ReadKey();

        }
    }
}
