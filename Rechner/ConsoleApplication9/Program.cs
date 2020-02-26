using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            double lol;
            double mama;
            double ergebnis = 0;

            do
            {
                Console.WriteLine("geben Sie eine Zahl an:");
                eingabe = Console.ReadLine();
                lol = Double.Parse(eingabe);
                Console.WriteLine("geben Sie noch eine Zahl an:");
                eingabe = Console.ReadLine();
                mama = Double.Parse(eingabe);

                Console.WriteLine("gib nun einen Buchstaben an der eine Operation ausführt");
                Console.WriteLine("Addition       = A");
                Console.WriteLine("Multiplikation = B");
                Console.WriteLine("Division       = C");
                Console.WriteLine("Subtraktion    = D");
                Console.WriteLine(lol + " hoch " + mama + "       = E");
                Console.WriteLine("Zum Beenden beliebige Taste drücken...");
                eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "a":
                    case "A":
                        ergebnis = (lol + mama);
                        Console.WriteLine("die Addition von " + lol + " und " + mama + " ergab " + ergebnis);
                        Console.WriteLine("ok nochmal.");
                        break;
                    case "b":
                    case "B":
                        ergebnis = (lol * mama);
                        Console.WriteLine("die Multiplikation von " + lol + " und " + mama + " ergab " + ergebnis);
                        Console.WriteLine("ok nochmal.");
                        break;
                    case "c":
                    case "C":
                        ergebnis = (lol / mama);
                        Console.WriteLine("die Division von " + lol + " und " + mama + " ergab " + ergebnis);
                        Console.WriteLine("ok nochmal.");
                        break;
                    case "d":
                    case "D":
                        ergebnis = (lol - mama);
                        Console.WriteLine("die Subtraktion von " + lol + " und " + mama + " ergab " + ergebnis);
                        Console.WriteLine("ok nochmal.");
                        break;
                    case "e":
                    case "E":
                        ergebnis = Math.Pow(lol, mama);
                        Console.WriteLine(lol + " hoch " + mama + " ist " + ergebnis);
                        Console.WriteLine("ok nochmal.");
                        break;
                }
            }
            while (eingabe == "A" || eingabe == "a" || eingabe == "B" || eingabe == "b" || eingabe == "C" || eingabe == "c" || eingabe == "D" || eingabe == "d" || eingabe == "E" || eingabe == "e");
        }
    }
}
