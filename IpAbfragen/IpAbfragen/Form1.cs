﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace IpAbfragen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IPAddress[] jep =  Dns.GetHostAddresses(Dns.GetHostName());
            label1.Text = jep[0].ToString();
        }
    }
}
