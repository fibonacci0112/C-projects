using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Bauernhof b = new Bauernhof();
            Bauer krause = new Bauer();

            krause.BekommenHof(b);

            b.ErzeugenTier(1);
            krause.ErzeugenTier(2);
            krause.ErzeugenTier(2);
            krause.ErzeugenTier(2);
            krause.ErzeugenTier(2);
            krause.ErzeugenTier(1);
            krause.ErzeugenTier(1);
            krause.ErzeugenTier(1);
            krause.ErzeugenTier(1);
            krause.BewirtschaftenHof();
        }
    }
}
