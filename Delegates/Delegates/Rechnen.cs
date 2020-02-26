using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Rechnen
    {
        private double zahl1;
        private double zahl2;

        public Rechnen(double zahl1, double zahl2)
        {
            this.zahl1 = zahl1;
            this.zahl2 = zahl2;
        }

        public double AusführenOperation(Operation operation)
        {
            return operation(zahl1,zahl2);
        }


    }
}
