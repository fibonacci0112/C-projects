using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace listentest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> jo = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                jo.Add(i);
            }

            foreach (int zahl in jo)
            {
                Console.WriteLine(zahl);
            }
        }
    }
}
