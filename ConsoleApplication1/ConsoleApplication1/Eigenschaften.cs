using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Eigenschaften
    {
        static private int x = 0;

        static public int X
        {
            get { return x;  }
            set { x = value; }
        }

        static public int Y {get; set;}
    }
}
