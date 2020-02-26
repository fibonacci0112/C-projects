using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ED        = "   \n   \n @ \n<X>\n ║ ";
            string EDhut     = "   \n_█_\n @>\n<X \n ║ ";
            string EDhuthoch = "_█_\n  \\ \n @/ \n<X \n ║ ";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("############################################################################\n\n  #######  #   #   ####       ###       ##      ##   ##  ####    \n     #     #   #   #         ##        #  #     # # # #  #       \n     #     #####   ####      #  ##    ######    #  #  #  ####    \n     #     #   #   #         ##  #   #      #   #     #  #       \n     #     #   #   ####       ####  #        #  #     #  ####    \n\n ############################################################################\n");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("{0}",ED);
            System.Threading.Thread.Sleep(500);
            while (true)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write("{0}", EDhut);
                System.Threading.Thread.Sleep(500);
                Console.SetCursorPosition(0, 10);
                Console.Write("{0}", EDhuthoch);
                System.Threading.Thread.Sleep(500);
               
            }
        }
    }
}
