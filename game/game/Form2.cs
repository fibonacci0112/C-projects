using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Punkte:";
            label3.Text = "Fehler";
            label2.Text = Convert.ToString(Übergabedaten.üpunkte);
            label4.Text = Convert.ToString(Übergabedaten.üfelher);
        }
    }
}
