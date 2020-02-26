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
    
    public partial class Form1 : Form
    {
        Form2 f = new Form2(0);
        public Form1()
        {
            InitializeComponent();

            Text = "Tetris";
            label1.Text = "Tetris";
            label2.Text = "Level";
            btn1.Text = "Start";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 9)
            {
                numericUpDown1.Value = 9;
            }
            else if (numericUpDown1.Value < 1)
            {
                numericUpDown1.Value = 1;
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
