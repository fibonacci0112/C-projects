using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegatetest
{
    public delegate double Operation(double a, double b);

    class Rechnen
    {
        
        private double a = 0;
        private double b = 0;

        public Rechnen(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double AusführenOperation(Operation operation)
        {
            return operation(a, b);
        }
    }
}
