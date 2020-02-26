using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    class StellplatzSorter:IComparer<Stellplatz>
    {
        public int Compare(Stellplatz x, Stellplatz y)
        {
            
            if (x.BerechneFlächeninhalt()>y.BerechneFlächeninhalt())
            {
                return 1;
            }
            if (x.BerechneFlächeninhalt() == y.BerechneFlächeninhalt())
            {
                return 0;
            }

            return -1;
        }
    }
}
