using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asp2011
{
    interface IGrundstück
    {
        double Grundpreis
        {
            get;
            set;
        }

        int BerechneFlächeninhalt();

        
    }
}
