using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Params
    {
        static public int Übergabe(params int[] p)
        {
            int summe = 0;

            foreach (int zahl in p)
            {
                summe += zahl;
            }
            return summe;
        }

    }
}
