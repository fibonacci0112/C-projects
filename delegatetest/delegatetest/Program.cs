using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegatetest
{
    class Program
    {
        static void Main(string[] args)
        {
            Rechnen r = new Rechnen(2,3);
            Rechenoperation ro = new Rechenoperation();
            nochmal n = new nochmal(3, 4);
            Console.WriteLine(r.AusführenOperation(ro.Addieren));
            Console.WriteLine(n.nochneop(ro.Addieren));
            Console.WriteLine(r.AusführenOperation(n.jop));

        }
    }
}
