using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmHauptfenster : Form
    {
        private Color[] farbe = { Color.White, Color.Red, Color.RosyBrown, Color.Orange, Color.Green, Color.DarkViolet, Color.DeepSkyBlue, Color.DarkTurquoise };
        private SolidBrush[] solidbrush = null;
        private Startdaten startdaten = null;
        private Tetris tetris = null;
        private const int BLOCKGRÖSSE = 30;


        public FrmHauptfenster()
        {
            InitializeComponent();
        }


        private void FrmHauptfenster_Load(object sender, EventArgs e)
        {
            startdaten = new Startdaten();
            FrmStart frmStart = new FrmStart(startdaten);
            if (frmStart.ShowDialog() == DialogResult.Cancel)
            {
                Close();
                return;
            }
            int a = startdaten.Level;
            tetris = new Tetris(15, 10, startdaten.Level);
            // tetris.SpielfeldGeändert += SpielfeldGeändert;
            // tetris.SpielEnde += Spielende;
            solidbrush = new SolidBrush[farbe.Length];
            for (int i = 0; i < farbe.Length; i++)
            {
                solidbrush[i] = new SolidBrush(farbe[i]);
            }
        }

        private void SpielfeldGeändert(object sender, EventArgs e)
        {
            pbSpielfeld.Invalidate();

        }

        private void pbSpielfeld_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int zeile = 0; zeile < tetris.Höhe; zeile++)
            {
                for (int spalte = 0; spalte < tetris.Breite; spalte++)
                {
                    {
                        g.FillRectangle(solidbrush[tetris[zeile, spalte]], (spalte * BLOCKGRÖSSE), (zeile * BLOCKGRÖSSE), BLOCKGRÖSSE, BLOCKGRÖSSE);
                    }
                }
            }
        }
    }
}