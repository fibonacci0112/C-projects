using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Schaf:Tier
    {
        public Schaf(double gewicht):base(gewicht)
        {
        }

        public override void Fressen(double essen)
        {
            this.gewicht=this.gewicht + essen * (0.333);
            Console.WriteLine("schaf frisst " + this.gewicht);
        }

        public override void Produzieren(Bauernhof b)
        {

            b.Wolle += (b.Zufallsgenerator.Next(200, 501) / 100.0);

            Console.WriteLine("schaf prod " + b.Wolle);
        }
    }
}
