using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Königreich
{
    abstract class Einwohner
    {
        protected int einkommen;

        public Einwohner(int einkommen)
        {
            this.einkommen = einkommen;
        }

        public int Geteinkommen()
        {
            return einkommen;
        }

        public virtual int BerechneZuVersteuerndesEinkommen()
        {
            return einkommen;
        }

        public virtual int BerechneSteuer()
        {
            int steuer = (int)((this.BerechneZuVersteuerndesEinkommen()/100.0)*10);
            if (steuer < 1)
            {
                steuer = 1;
            }
            return steuer;
        }
    }
}
