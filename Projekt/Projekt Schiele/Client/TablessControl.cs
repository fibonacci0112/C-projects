using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{


    class TablessControl : TabControl
    {
        public Form1 Form1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }
    }
}

