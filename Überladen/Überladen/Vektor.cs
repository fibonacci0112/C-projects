using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Überladen
{
    class Vektor
    {
        private double[] wert;

        public Vektor()
        {
            wert = new double[3];
        }

        public Vektor(double a, double b)
        {
            wert = new double[] { a, b };
        }

        public Vektor(double a, double b, double c)
        {
            wert = new double[] { a, b, c };
        }
        public Vektor(double[] array)
        {
            this.wert = array;
        }

        public Vektor(Vektor v)
        {
            this.wert = v.wert;
        }

        public double this[int index] { get; set; }

        public Vektor Addieren(Vektor v)
        {
            if (v.wert.Length!=this.wert.Length)
            {
                throw new RankException();
            }
            Vektor ergebnis = new Vektor(v);

            for (int i = 0; i < this.wert.Length; i++)
            {
                ergebnis[i] = this.wert[i] + v.wert[i];
            }

            return ergebnis;
        }

        public Vektor Multiplizieren(double a)
        {

            Vektor ergebnis = new Vektor(this);

            for (int i = 0; i < this.wert.Length; i++)
            {
                ergebnis[i] = this.wert[i] * a;
            }

            return ergebnis;
        }

        public double Multiplizieren(Vektor v)
        {
            if (v.wert.Length != this.wert.Length)
            {
                throw new RankException();
            }
            double ergebnis = 0;

            for (int i = 0; i < this.wert.Length; i++)
            {
                ergebnis += this.wert[i] * v.wert[i];
            }

            return ergebnis;
        }

        public Vektor Subtrahieren(Vektor v)
        {
            if (v.wert.Length != this.wert.Length)
            {
                throw new RankException();
            }
            Vektor ergebnis = new Vektor(v);

            for (int i = 0; i < this.wert.Length; i++)
            {
                ergebnis[i] = this.wert[i] - v.wert[i];
            }

            return ergebnis;
        }

        public Vektor Dividieren(Vektor v)
        {
            if (v.wert.Length != this.wert.Length)
            {
                throw new RankException();
            }
            Vektor ergebnis = new Vektor(v);

            for (int i = 0; i < this.wert.Length; i++)
            {
                ergebnis[i] = this.wert[i] / v.wert[i];
            }

            return ergebnis;
        }


        public static Vektor operator +(Vektor v1, Vektor v2)
        {
            return v1.Addieren(v2);   
        }

        public static Vektor operator -(Vektor v1, Vektor v2)
        {
            return v1.Subtrahieren(v2);
        }

        public static double operator *(Vektor v1, Vektor v2)
        {
            return v1.Multiplizieren(v2);
        }

        public static Vektor operator *(Vektor v1,double a)
        {
            return v1.Multiplizieren(a);
        }

        public static Vektor operator /(Vektor v1, Vektor v2)
        {
            return v1.Dividieren(v2);
        }

        public static Vektor operator ++(Vektor v1)
        {
            for (int i = 0; i < v1.wert.Length; i++)
            {
                v1.wert[i]++;
            }

            return v1;
        }

        public static Vektor operator --(Vektor v1)
        {
            for (int i = 0; i < v1.wert.Length; i++)
            {
                v1.wert[i]--;
            }

            return v1;
        }


    }
}
