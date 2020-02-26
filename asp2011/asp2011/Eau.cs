using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    class Eau :Stellplatz
    {
        private bool eigenerStrand;
        private double entfernungStrand;

        public Eau(bool eigenerStrand, double entfernungStrand, int länge, int breite, bool schwimmbad):base(länge,breite,"Eau",schwimmbad)
        {
            this.eigenerStrand = eigenerStrand;
            this.entfernungStrand = entfernungStrand;
        }

        public override double ErmittelnFaktor()
        {
            return 1.2;
        }

        public override string ToString()
        {
            return base.ToString() + "\neigener Strand " + ErmittelnText(eigenerStrand) + "\nEntfernung zum Strand: " + entfernungStrand;
        }
    }
}
