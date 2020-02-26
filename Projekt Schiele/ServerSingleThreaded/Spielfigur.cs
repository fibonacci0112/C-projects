using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerSingleThreaded
{
    class Spielfigur
    {
        private int healthPoints;
        private int level;
        private int angriffsstärke;
        private int verteidigungsstärke;
        private int xposition;
        private int yposition;
        private int[,] bewegungsareal;
        private Random zufall;
        private int art;
        private string partei;
        
        public int[,] Bewegungsareal
        {
            get { return bewegungsareal; }
            set { bewegungsareal = value; }
        }

        public int Xposition
        {
            get { return xposition; }
            set { xposition = value; }
        }

        public int Yposition
        {
            get { return yposition; }
            set { yposition = value; }
        }

        void WerteSetzen(int art, int klasse)
        {
            this.healthPoints = (art / 2) * 10;
            this.level = 1;
            this.angriffsstärke = art * klasse;
            this.verteidigungsstärke = art * (((klasse - 20) * (-1)) + 20);

            switch (art)
            {
                case 10:
                    bewegungsareal = new int[,]{{0,0,0,1,0,0,0},
                                                {0,0,1,1,1,0,0},
                                                {0,1,3,3,3,1,0},
                                                {1,1,3,0,3,1,1},
                                                {0,1,3,3,3,1,0},
                                                {0,0,1,1,1,0,0},
                                                {0,0,0,1,0,0,0}};
                    break;

                case 20:
                    bewegungsareal = new int[,]{{0,0,0,0,0,0,0},
                                                {0,0,0,3,0,0,0},
                                                {0,0,3,3,3,0,0},
                                                {0,3,3,0,3,3,0},
                                                {0,0,3,3,3,0,0},
                                                {0,0,0,3,0,0,0},
                                                {0,0,0,0,0,0,0}};
                    break;

                case 30:
                    bewegungsareal = new int[,]{{0,0,0,2,0,0,0},
                                                {0,0,2,2,2,0,0},
                                                {0,2,3,3,3,2,0},
                                                {2,2,3,0,3,2,2},
                                                {0,2,3,3,3,2,0},
                                                {0,0,2,2,2,0,0},
                                                {0,0,0,2,0,0,0}};
                    break;

                default:
                    break;
            }
        }

        public Spielfigur(int artDerFigur, string partei, int xspawn, int yspawn)
        {
            this.zufall = new Random();
            this.xposition = xspawn;
            this.yposition = yspawn;
            this.art = artDerFigur;
            switch (partei)
            {
                case "red":
                    this.partei = "red";
                    switch (artDerFigur)
                    {
                        case 300:
                            WerteSetzen(30, 10);
                            break;

                        case 200:
                            WerteSetzen(20, 10);
                            break;

                        case 100:
                            WerteSetzen(10, 10);
                            break;

                        default:
                            break;
                    }
                    break;

                case "green":
                    this.partei = "green";
                    switch (artDerFigur)
                    {
                        case 300:
                            WerteSetzen(30, 20);
                            break;

                        case 200:
                            WerteSetzen(20, 20);
                            break;

                        case 100:
                            WerteSetzen(10, 20);
                            break;

                        default:
                            break;
                    }
                    break;

                case "blue":
                    this.partei = "blue";
                    switch (artDerFigur)
                    {
                        case 300:
                            WerteSetzen(30, 30);
                            break;

                        case 200:
                            WerteSetzen(20, 30);
                            break;

                        case 100:
                            WerteSetzen(10, 30);
                            break;

                        default:
                            break;
                    }
                    break;
            }
        }

        public void GreiftAn(Spielfigur figur)
        {
            int ergebnis = this.angriffsstärke - (((figur.verteidigungsstärke / 10) * 4) + zufall.Next(-5, 5));

            if (ergebnis < 0)
            {
                ergebnis = 1;
            }

            figur.healthPoints -= ergebnis;
        }

        public void WirdBewegt(int x, int y)
        {
            this.xposition = x;
            this.yposition = y;
        }

        public void LevelUp()
        {
            this.level += this.level;
            this.angriffsstärke *= this.level;
            this.verteidigungsstärke *= this.level;
        }

        public override string ToString()
        {
            return this.art + "," + this.healthPoints + "," + this.angriffsstärke + "," + this.verteidigungsstärke + "," + this.level + "," + partei + "," + xposition + "," + yposition;
        }
    }
}

