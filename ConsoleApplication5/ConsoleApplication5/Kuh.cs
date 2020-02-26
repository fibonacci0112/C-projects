using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Kuh:Tier
    {
        public Kuh(double gewicht):base(gewicht)
        {
        }

        public override void Fressen(double essen)
        {
            this.gewicht += essen * 0.25;

            Console.WriteLine("Kuh frisst" + this.gewicht);
        }

        public override void Produzieren(Bauernhof b)
        {
            b.Milch += (b.Zufallsgenerator.Next(1000, 2001) / 100.0);

            Console.WriteLine("kuh prod" + b.Milch);
        }
    }
}
