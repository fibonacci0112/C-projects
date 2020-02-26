using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Indexer
    {
        private int[] wert={1,2,3,4};

        public int this[int index]
        {
            get {return wert[index];}
            set {wert[index] =value;}
        }

    }
}
