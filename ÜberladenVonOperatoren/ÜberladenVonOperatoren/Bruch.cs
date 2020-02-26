using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ÜberladenVonOperatoren
{
    class Bruch
    {
        private int zähler;

        public int Zähler
        {
            get { return zähler; }
            set { zähler = value; }
        }
        private int nenner;

        public int Nenner
        {
            get { return nenner; }

            set
            {
                if (nenner == 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    nenner = value;
                }
            }
        }

        public Bruch()
        {
            this.zähler = 0;
            this.nenner = 1;
        }

        public Bruch(int zähler, int nenner)
            : this()
        {
            if (nenner == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                this.nenner = nenner;
            }

            this.zähler = zähler;
        }

        public double GetDezimalwert()
        {
            return (double)zähler / (double)nenner;
        }

        public override string ToString()
        {
            return zähler + "/" + nenner;
        }

        private int BestimmeGGT()
        {
            int rest = 0;
            int zähler1 = Math.Abs(zähler);
            int nenner1 = Math.Abs(nenner);

            while (nenner1 > 0)
            {
                rest = zähler1 % nenner1;
                zähler1 = nenner1;
                nenner1 = rest;
            }

            return zähler1;
        }

        public void Kürzen()
        {
            int teiler = this.BestimmeGGT();
            zähler /= teiler;
            nenner /= teiler;
        }

        public Bruch Addieren(Bruch b)
        {
            Bruch dunervst = new Bruch(((this.zähler * b.nenner) + (this.nenner * b.zähler)), (this.nenner * b.nenner));
            b.Kürzen();
            return b;
        }


        public Bruch Subtrahieren(Bruch b)
        {
            Bruch dunervst = new Bruch(((this.zähler * b.nenner) - (this.nenner * b.zähler)), (this.nenner * b.nenner));
            dunervst.Kürzen();
            return dunervst;
        }

        public Bruch Multiplizieren(Bruch b)
        {
            Bruch dunervst = new Bruch((this.zähler * b.zähler), (b.nenner * this.nenner));
            dunervst.Kürzen();
            return dunervst;
        }

        public Bruch Dividieren(Bruch b)
        {
            Bruch dunervst = new Bruch((this.zähler * b.nenner), (b.zähler * this.nenner));
            dunervst.Kürzen();
            return dunervst;
        }

        public static Bruch operator +(Bruch b1, Bruch b2)
        {
            return b1.Addieren(b2);
        }
        public static Bruch operator -(Bruch b1, Bruch b2)
        {
            return b1.Subtrahieren(b2);
        }
        public static Bruch operator /(Bruch b1, Bruch b2)
        {
            return b1.Dividieren(b2);
        }
        public static Bruch operator *(Bruch b1, Bruch b2)
        {
            return b1.Multiplizieren(b2);
        }
        public static bool operator <(Bruch b1, Bruch b2)
        {
            return (b1.GetDezimalwert()) < (b2.GetDezimalwert());
        }
        public static bool operator >(Bruch b1, Bruch b2)
        {
            return (b1.GetDezimalwert()) > (b2.GetDezimalwert());
        }
        public static bool operator <=(Bruch b1, Bruch b2)
        {
            b1.Kürzen();
            b2.Kürzen();
            if (b1.zähler==b2.zähler&&b1.nenner==b2.nenner)
            {
                return true;
            }
            return (b1.GetDezimalwert()) < (b2.GetDezimalwert());
        }
        public static bool operator >=(Bruch b1, Bruch b2)
        {
            b1.Kürzen();
            b2.Kürzen();
            if (b1.zähler == b2.zähler && b1.nenner == b2.nenner)
            {
                return true;
            }
            return (b1.GetDezimalwert()) > (b2.GetDezimalwert());
        }
        public static bool operator ==(Bruch b1, Bruch b2)
        {
            b1.Kürzen();
            b2.Kürzen();
            if (b1.zähler == b2.zähler && b1.nenner == b2.nenner)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Bruch b1, Bruch b2)
        {
            b1.Kürzen();
            b2.Kürzen();
            if (b1.zähler == b2.zähler && b1.nenner == b2.nenner)
            {
                return false;
            }
            return true;
        }
        public static Bruch operator ++(Bruch b1)
        {
            Bruch bla=new Bruch();
            bla.zähler=b1.zähler + b1.nenner;
            return bla;
        }
        public static Bruch operator --(Bruch b1)
        {
            Bruch bla = new Bruch();
            bla.zähler = b1.zähler - b1.nenner;
            return bla;
        }

    }
}
