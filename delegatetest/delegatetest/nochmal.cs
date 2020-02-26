using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegatetest
{
    class nochmal
    {
        private double a = 0;
        private double b = 0;

        public nochmal(double a, double b)
        {
            this.b = b;
            this.a = a;
        }

        public double nochneop(Operation operation)
        {
            return operation(a, b);
        }

        public double jop(double a, double b)
        {
            return a - b;
        }
    }
}
