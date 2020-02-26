using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Königreich
{
    class Program
    {
        static void Main(string[] args)
        {
            König k = new König(100000);
            Adel a = new Adel(10000);
            Bauer b = new Bauer(1000);
            Leibeigener l = new Leibeigener(100);

            Console.WriteLine("König " + k.BerechneZuVersteuerndesEinkommen());
            Console.WriteLine("Adel " + a.BerechneZuVersteuerndesEinkommen());
            Console.WriteLine("Bauer " + b.BerechneZuVersteuerndesEinkommen());
            Console.WriteLine("Leibeigener " + l.BerechneZuVersteuerndesEinkommen());

            Console.WriteLine("König " + k.BerechneSteuer());
            Console.WriteLine("Adel " + a.BerechneSteuer());
            Console.WriteLine("Bauer " + b.BerechneSteuer());
            Console.WriteLine("Leibeigener " + l.BerechneSteuer());

           
        }
    }
}
