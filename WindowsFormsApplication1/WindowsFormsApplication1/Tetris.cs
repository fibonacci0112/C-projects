using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Tetris
    {
        private Block block = null;
        private int farbeobergrenze;
        private int level;
        private int linien;
        private Block nächsterBlock = null;
        private int punkte;
        private int[,] spielfeld;
        private Random zufall;

        public Block Block { get { return block; } }
        public int Breite { get { return spielfeld.GetLength(1); } }
        public int Höhe { get { return spielfeld.GetLength(0); } }
        public int Level { get { return level; } }
        public int Linien { get { return linien; } }
        public Block Nächsterblock { get { return nächsterBlock; } }
        public int Punkte { get { return punkte; } }
        public int this[int zeile, int spalte] { get { return spielfeld[zeile, spalte]; } }

        public event EventHandler<EventArgs> SpielfeldGeändert;
        public event EventHandler<EventArgs> SpielEnde;

        public Tetris(int x, int y, int level)
        {
            spielfeld = new int[x, y];


        }

        protected void OnSpielfeldGeändert()
        {
            if (SpielfeldGeändert != null)
            {
                SpielfeldGeändert(this, new EventArgs());
            }


        }

        protected void OnSpielEnde()
        {
            if (SpielEnde != null)
            {
                SpielEnde(this, new EventArgs());
            }
        }
    }
}
