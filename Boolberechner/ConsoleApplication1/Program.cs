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
            do
            {
                bool a;
                bool b;
                bool c;
                string eingabe;

                Console.WriteLine("gib nacheinander 3 bools an:");
                eingabe = Console.ReadLine();
                a = Boolean.Parse(eingabe);
                eingabe = Console.ReadLine();
                b = Boolean.Parse(eingabe);
                eingabe = Console.ReadLine();
                c = Boolean.Parse(eingabe);

                if ((a && !b && !c) || (!a && !b && c) || (!a && b && !c))
                {
                    Console.WriteLine("LED1");
                }

                else if ((a && b && !c) || (a && !b && c) || (!a && b && c))
                {
                    Console.WriteLine("LED2");
                }
                else if (a && b && c)
                {
                    Console.WriteLine("LED3");
                }
            }
            while (true);
        }
    }
}
