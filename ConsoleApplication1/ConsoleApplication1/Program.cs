using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {



            for (int i = 1000; i < 10000; i+=10)
            {
                Console.Beep(i, 100);
                Console.WriteLine(i);
            }
        }
    }
}
