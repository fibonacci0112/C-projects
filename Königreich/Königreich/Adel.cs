using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Königreich
{
    class Adel : Einwohner
    {
        public Adel(int einkommen)
            : base(einkommen)
        {
        }

        public override int BerechneSteuer()
        {
            int steuer = base.BerechneSteuer();
            if (steuer < 20)
            {
                return 20;
            }
            return steuer;
        }

        
    }
}
