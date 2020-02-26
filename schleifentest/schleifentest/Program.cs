using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace schleifentest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[20, 20];
            int x = 0;
            int y = 0;
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    array[i,j] = x;
                    x++;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.WriteLine(array[j,i]);
                    System.Threading.Thread.Sleep(10);
                }
            }
        }
    }
}
