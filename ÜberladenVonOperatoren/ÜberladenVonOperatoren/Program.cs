using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ÜberladenVonOperatoren
{
    class Program
    {
        static void Main(string[] args)
        {

            Bruch erster = new Bruch(6, 4);
            Bruch zweiter = new Bruch(1, 2);

            Console.WriteLine(erster.Dividieren(zweiter).ToString());
            Console.WriteLine(erster.Multiplizieren(zweiter).ToString());
            Console.WriteLine(erster.Addieren(zweiter).ToString());
            Console.WriteLine(erster.Subtrahieren(zweiter).ToString());

            Bruch b3 = erster + zweiter;

            Console.WriteLine(b3);
        }
    }
}
