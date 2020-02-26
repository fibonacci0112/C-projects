using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Königreich
{
    class König : Einwohner
    {
        public König(int einkommen)
            : base(einkommen)
        {
        }

        public override int BerechneSteuer()
        {
            return 0;
        }
    }
}
