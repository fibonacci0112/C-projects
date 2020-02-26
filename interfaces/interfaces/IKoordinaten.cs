using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interfaces
{
    interface IKoordinaten
    {
        int X { get; set; }

        int Y { get; set; }

        double Betrag();
    }
}
