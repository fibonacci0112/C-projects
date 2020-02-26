using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    abstract class Tier
    {
        protected double gewicht;

        public Tier(double gewicht)
        {
            this.gewicht = gewicht;
        }

        public abstract void Fressen(double essen);

        public abstract void Produzieren(Bauernhof b);
    }
}
