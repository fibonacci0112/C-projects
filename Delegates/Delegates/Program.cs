using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Rechnen r1 = new Rechnen(1, 2);
            Rechnenoperation ro1 = new Rechnenoperation();
            Operation o = delegate(double a, double b) { return a % b; };


            o += ro1.Multiplizieren;


            Console.WriteLine(r1.AusführenOperation(o));

            o -= ro1.Multiplizieren;

            Console.WriteLine(r1.AusführenOperation(o));
        }
    }
}
