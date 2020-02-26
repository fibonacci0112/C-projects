using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[31, 31];

            Random ra = new Random();
            string r;
            while (true)
            {
                Console.Write((r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))));
                Console.Write((r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))));
                Console.Write((r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))) + (r = Convert.ToString(ra.Next(1, 999999999))));
                System.Threading.Thread.Sleep(100);
                Console.Clear();

            }
        }
    }
}
