using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate double Operation(double a, double b);

    class Rechnenoperation
    {
        public double Addieren(double zahl1, double zahl2)
        {
            return zahl1+zahl2;
        }
        public double Dividieren(double zahl1, double zahl2)
        {
            return zahl1/zahl2;
        }
        public double Multiplizieren(double zahl1, double zahl2)
        {
            return zahl1*zahl2;
        }
        public double Subtrahieren(double zahl1, double zahl2)
        {
            return zahl1-zahl2;
        }
    }
}
