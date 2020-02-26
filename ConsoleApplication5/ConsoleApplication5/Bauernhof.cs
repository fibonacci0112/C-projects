using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Bauernhof
    {
        private Tier[] nutzTiere = new Tier[200];
        private int anzahlTiere;
        private Random zufallsgenerator=new Random();

        public Random Zufallsgenerator
        {
            get { return zufallsgenerator; }
        }

        private double milch;

        public double Milch
        {
            get { return milch; }
            set { milch = value; }
        }

        private double wolle;

        public double Wolle
        {
            get { return wolle; }
            set { wolle = value; }
        }

        public Bauernhof()
        {

        }

        public void ErzeugenTier(int art)
        {
            if (art==1)
            {
                nutzTiere[anzahlTiere] = new Kuh(100);
                anzahlTiere++;
            }
            else if (art == 2)
            {
                nutzTiere[anzahlTiere] = new Schaf(10);
                anzahlTiere++;
            }
            else
            {
                throw new OperationCanceledException();
            }

        }

        public void FütternTiere()
        {
            for (int i = 0; i < anzahlTiere; i++)
            {
                nutzTiere[i].Fressen(4.5);
            }
        }

        public void Produzieren()
        {
            for (int i = 0; i < anzahlTiere; i++)
            {
                nutzTiere[i].Produzieren(this);
            }
        }
    }
}
