using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Bauer
    {
        private Bauernhof meinHof;

        public void BekommenHof(Bauernhof b)
        {
            this.meinHof = b;
        }

        public void BewirtschaftenHof()
        {
            meinHof.Produzieren();
            meinHof.FütternTiere();
        }

        public void ErzeugenTier(int art)
        {
            meinHof.ErzeugenTier(art);
        }
    }
}
