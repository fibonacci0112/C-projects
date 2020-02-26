using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    static class Übergabe
    {
        static private decimal wert;

        static public void Getwert(decimal eingabe)
        {
            wert = eingabe;
        }
    }
}
