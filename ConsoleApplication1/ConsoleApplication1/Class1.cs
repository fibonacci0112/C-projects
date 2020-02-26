using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    static class Reference
    {


        static public void Tausch(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

    }
}
