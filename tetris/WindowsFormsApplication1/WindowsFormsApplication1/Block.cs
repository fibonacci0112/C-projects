using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Block
    {
        protected int zeile;
        protected int spalte;
        protected int farbe;

        public Block(int zeile, int spalte, int farbe)
        {
            this.zeile = zeile;
            this.spalte = spalte;
            this.farbe = farbe;
        }
    }
}
