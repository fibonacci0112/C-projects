using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int User = 0;
            int KI = 0;
            string Ergebniss = String.Empty;
            string Name = String.Empty;

            Console.WriteLine("gib bitte deinen Namen an");
            Name = Console.ReadLine();

            while (User <= 10 || KI <= 10)
            {

                Random zufall = new Random();
                int number = zufall.Next(1, 4);
                Console.WriteLine("gebe 1 2 oder 3 an");
                int Eingabe = Convert.ToInt32(Console.ReadLine());

                if (number == Eingabe)
                {
                    Console.WriteLine("Richtig");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();

                    User++;



                }

                else
                {

                    Console.WriteLine("Punkt für den gegner");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();

                    KI++;

                }

            }
        }
    }
}
