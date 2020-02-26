using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Punkt[] array = new Punkt[5];


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Punkt(i,200/(i+1));
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Betrag());
            }

            Array.Sort(array);

            Console.WriteLine("Nach Betrag:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Betrag());
            }

            Console.WriteLine("Nach X:");

            Array.Sort(array,new Xsorter());

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].X);
            }

            Console.WriteLine("Nach Y:");

            Array.Sort(array,new Ysorter());

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Y);
            }
        }
    }
}
