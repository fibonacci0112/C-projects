using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    abstract class Stellplatz : IGrundstück
    {
        private int länge;
        private int breite;
        private string typ;
        private bool schwimmbad;

        public Stellplatz(int länge, int breite, string typ, bool schwimmbad)
        {
            if (breite<0||länge<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.länge = länge;
            this.breite = breite;
            this.typ = typ;
            this.schwimmbad = schwimmbad;
        }

        public double Grundpreis
        {
            set { this.Grundpreis = value; }
            get { return Grundpreis; }
        }

        public int BerechneFlächeninhalt()
        {
            return länge * breite;
        }

        public abstract double ErmittelnFaktor();

        public double ErmittelnKosten()
        {

            return ErmittelnFaktor() * BerechneFlächeninhalt() * Grundpreis;
        }

        public string ErmittelnText(bool variable)
        {
            string ausgabe = "nein";
            if (variable)
            {
                ausgabe = "ja";
            }
            return ausgabe;
        }

        public override string ToString()
        {
            return "Der Stellplatz ist " + länge + " m lang und " + breite + " m breit und hat:\nSchwimmbad " + ErmittelnText(schwimmbad);
        }
    }
}
