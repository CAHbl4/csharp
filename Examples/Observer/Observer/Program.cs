using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public delegate void ChangeInBank(object ob);
    public delegate double Func(double x);
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Иванов", 50);
            Student st2 = new Student("Петров", 50);
            Student st3 = new Student("Козлов", 50);
            Bank bank = new Bank("Беларусбанк", 10, st1.OnChangeInBank);
            Console.WriteLine(st1);
            Console.WriteLine(st2);
            Console.WriteLine(st3);
            Console.WriteLine();
            bank.observer+= st3.OnChangeInBank;
            Console.WriteLine(st3);
            Console.WriteLine();
            bank.DollarRate = 3;
            //bank.observer(new Bank("Левый", (decimal)0.5));
            Console.WriteLine(st1);
            Console.WriteLine(st2);
            Console.WriteLine(st3);
            Console.WriteLine( );
            Func f1 = Math.Sin; f1 += Math.Cos;
            Func f2 = Math.Cos; f2 += Math.Atan;
            Func f = f1;
            f += Math.Asin;
            f += Math.Sin;
            f += Math.Cos;
            f += f2;
            f(4);
            foreach (Delegate d in f.GetInvocationList())  Console.WriteLine(d.Method);
                Console.WriteLine();
                f -= f1;
                foreach (Delegate d in f.GetInvocationList()) Console.WriteLine(d.Method);
                Console.WriteLine();
                Func ff = f1 - f;
                foreach (Delegate d in ff.GetInvocationList()) Console.WriteLine(d.Method);
            Console.ReadKey();
        }
    }
}
