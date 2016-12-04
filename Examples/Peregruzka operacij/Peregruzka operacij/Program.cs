using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Peregruzka_operacij
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2,5);
            Fraction f2 = -f1;
            Console.WriteLine(f1+"  "+f2);
            if (f1) Console.WriteLine("первая дробь - истинная дробь!");
            Console.WriteLine(f1 * f2 + "  " + 3 * f1 + "  " + f2 * 5);
            Fraction f3 = new Fraction(1, 5);
            if(f1 && f3)
                Console.WriteLine("обе дроби истинные");
            else
                Console.WriteLine("Не обязательно обе дроби истинные");
            double d = (double)f3;
            
            Console.WriteLine(d);
            Fraction f = 6;
            Console.WriteLine(f);
            Console.ReadKey();
        }
    }
}
