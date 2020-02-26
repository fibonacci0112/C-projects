using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerSingleThreaded
{
    class Spieler
    {
        private List<Spielfigur> Spielfiguren = new List<Spielfigur>();

        internal List<Spielfigur> Spielfiguren1
        {
            get { return Spielfiguren; }
            set { Spielfiguren = value; }
        }
        private string partei;
        private int geld;
        private int bewpnkt;

        public int Bewpnkt
        {
            get { return bewpnkt; }
        }

        public string Partei
        {
            get { return partei; }
            set
            {
                partei = value;
                Console.WriteLine(value);

                switch (partei)
                {
                    case "red":
                        this.geld = 1000;
                        this.bewpnkt = 30;
                        break;

                    case "green":
                        this.geld = 2000;
                        this.bewpnkt = 20;
                        break;

                    case "blue":
                        this.geld = 3000;
                        this.bewpnkt = 10;
                        break;

                    default:
                        break;
                }
            }
        }

        public int Geld
        {
            get { return geld; }
        }

        public Spieler()
        {
        }

        public Spielfigur NeueFigur(int art, int xspawn, int yspawn)
        {
            geld -= art;
            Spielfiguren.Add(new Spielfigur(art, this.partei, xspawn, yspawn));
            Console.WriteLine("Neue Figur: " + Spielfiguren[Spielfiguren.Count - 1].ToString() + " Nr.: " + (Spielfiguren.Count));
            return Spielfiguren[Spielfiguren.Count - 1];
        }
    }
}

