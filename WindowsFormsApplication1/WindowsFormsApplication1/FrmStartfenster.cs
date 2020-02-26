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
    
    public partial class FrmStart : Form
    {
        private Startdaten startDaten = null;


        public FrmStart(Startdaten startDaten)
        {
            InitializeComponent();

            this.startDaten = startDaten;
            Text = "Tetris";
            label1.Text = "Tetris";
            label2.Text = "Level";
            btnStart.Text = "Start";
            btnStart.DialogResult = DialogResult.OK;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            startDaten.Level = (int)numericUpDown1.Value;
        }
    }
}
