using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Out
    {
        static public void Rückgabe(int a, int b, out int c)
        {
            c = a + b;
        }
    }
}
