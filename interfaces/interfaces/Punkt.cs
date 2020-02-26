using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interfaces
{
    class Punkt:IKoordinaten,IComparable<Punkt>
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Punkt()
        {

        }

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double Betrag()
        {
            return Math.Abs(this.x) + Math.Abs(this.y);
        }

        public int CompareTo(Punkt p)
        {
            return this.Betrag().CompareTo(p.Betrag());
        }
    }
}
