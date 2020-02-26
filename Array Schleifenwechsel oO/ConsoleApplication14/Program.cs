using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] feld = new string[9,9];
            feld[0, 0] = " "; feld[1, 0] = " "; feld[2, 0] = " "; feld[3, 0] = " "; feld[4, 0] = " "; feld[5, 0] = " "; feld[6, 0] = " "; feld[7, 0] = " "; feld[8, 0] = " ";
            feld[0, 1] = " "; feld[1, 1] = " "; feld[2, 1] = " "; feld[3, 1] = " "; feld[4, 1] = " "; feld[5, 1] = " "; feld[6, 1] = " "; feld[7, 1] = " "; feld[8, 1] = " ";
            feld[0, 2] = " "; feld[1, 2] = " "; feld[2, 2] = " "; feld[3, 2] = " "; feld[4, 2] = " "; feld[5, 2] = " "; feld[6, 2] = " "; feld[7, 2] = " "; feld[8, 2] = " ";
            feld[0, 3] = " "; feld[1, 3] = " "; feld[2, 3] = " "; feld[3, 3] = " "; feld[4, 3] = " "; feld[5, 3] = " "; feld[6, 3] = " "; feld[7, 3] = " "; feld[8, 3] = " ";
            feld[0, 4] = " "; feld[1, 4] = " "; feld[2, 4] = " "; feld[3, 4] = " "; feld[4, 4] = " "; feld[5, 4] = " "; feld[6, 4] = " "; feld[7, 4] = " "; feld[8, 4] = " ";
            feld[0, 5] = " "; feld[1, 5] = " "; feld[2, 5] = " "; feld[3, 5] = " "; feld[4, 5] = " "; feld[5, 5] = " "; feld[6, 5] = " "; feld[7, 5] = " "; feld[8, 5] = " ";
            feld[0, 6] = " "; feld[1, 6] = " "; feld[2, 6] = " "; feld[3, 6] = " "; feld[4, 6] = " "; feld[5, 6] = " "; feld[6, 6] = " "; feld[7, 6] = " "; feld[8, 6] = " ";
            feld[0, 7] = " "; feld[1, 7] = " "; feld[2, 7] = " "; feld[3, 7] = " "; feld[4, 7] = " "; feld[5, 7] = " "; feld[6, 7] = " "; feld[7, 7] = " "; feld[8, 7] = " ";
            feld[0, 8] = " "; feld[1, 8] = " "; feld[2, 8] = " "; feld[3, 8] = " "; feld[4, 8] = " "; feld[5, 8] = " "; feld[6, 8] = " "; feld[7, 8] = " "; feld[8, 8] = " ";
            int abwechselnd = 0;


            Console.WriteLine("geben sie die Nummerierung für das ausgewählte Feld ein\n");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("1,1|1,2|1,3|1,4|1,5|1,6|1,7|1,8|1,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("2,1|2,2|2,3|2,4|2,5|2,6|2,7|2,8|2,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("3,1|3,2|3,3|3,4|3,5|3,6|3,7|3,8|3,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("4,1|4,2|4,3|4,4|4,5|4,6|4,7|4,8|4,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("5,1|5,2|5,3|5,4|5,5|5,6|5,7|5,8|5,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("6,1|6,2|6,3|6,4|6,5|6,6|6,7|6,8|6,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("7,1|7,2|7,3|7,4|7,5|7,6|7,7|7,8|7,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("8,1|8,2|8,3|8,4|8,5|8,6|8,7|8,8|8,9");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("9,1|9,2|9,3|9,4|9,5|9,6|9,7|9,8|9,9");
            Console.WriteLine();

            while (true)
            {
                if (abwechselnd % 2 < 1)
                {
                    Console.WriteLine("Junge");
                }
                else
                {
                    Console.WriteLine("mädchen");
                }
                abwechselnd++;
            }
        }
    }
}
