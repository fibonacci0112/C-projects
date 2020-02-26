using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interfaces
{
    class Xsorter:IComparer
    {
        public int Compare(object x, object y)
        {
            Punkt p1 = (Punkt)x;
            Punkt p2 = (Punkt)y;

            return p1.X.CompareTo(p2.X);
        }
    }
}
