using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    class LaVille :Stellplatz
    {
        private bool ruhigeLage;
        private double entfernungZumStadtkern;

        public LaVille(bool ruhigeLage, double entfernungZumStadtkern, int länge, int breite, bool schwimmbad):base(länge,breite,"LaVille",schwimmbad)
        {
            this.ruhigeLage = ruhigeLage;
            this.entfernungZumStadtkern = entfernungZumStadtkern;
        }

        public override double ErmittelnFaktor()
        {
            return 0.9;
        }

        public override string ToString()
        {
            return base.ToString()+"\nruhigeLage: "+ ErmittelnText(ruhigeLage) + "\nEntfernung zum Stadtkern: " + entfernungZumStadtkern;
        }
    }
}
