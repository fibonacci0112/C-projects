using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI
{
    class Program
    {
        private static decimal pi = 1;
        private static decimal ungerade = 1;
        private static decimal gerade = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(berechner(1,1)*2);
        }

        static public decimal berechner(decimal a, decimal b)
        {
            gerade++;
            ungerade += 2;
            while (gerade<1000)
            {
                pi *= 1 + gerade / ungerade * berechner(a+gerade, b+ungerade);
            }

            
            return pi;
        }
    }
}

