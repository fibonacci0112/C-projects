using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class BlockO : Block
    {
        private int zeile;
        private int spalte;
        private int farbe;
        private int[,] blockfeld = new int[2, 3];

        public int Zeile
        {
            get { return zeile; }
            set { zeile = value; }
        }

        public int Spalte
        {
            get { return spalte; }
            set { spalte = value; }
        }

        public int Farbe
        {
            get { return farbe; }
            set { farbe = value; }
        }

        public int[,] Blockfeld
        {
            get { return blockfeld; }
            set { blockfeld = value; }
        }

        public int this[int zeile, int spalte] { get { return blockfeld[zeile, spalte]; } } 

        public BlockO(int zeile, int spalte, int farbe):base(zeile, spalte, farbe)
        {
            this.zeile = zeile;
            this.spalte = spalte;
            this.farbe = farbe;
        }

        public int[,] Zeichnen()
        {
            blockfeld[0,0]=1;
            blockfeld[0,1]=1;
            blockfeld[1,0]=1;
            blockfeld[1,1]=1;
            return blockfeld;
        }
        

    }
}
