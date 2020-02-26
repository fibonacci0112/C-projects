using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Königreich
{
    class Leibeigener : Bauer
    {
        public Leibeigener(int einkommen):base(einkommen)
        {
        }

        public override int BerechneZuVersteuerndesEinkommen() 
        {
            int bla = einkommen - 12;
            return bla;
        }
    }
}
