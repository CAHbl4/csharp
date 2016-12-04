using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty
{
    public delegate double Func(double x);
    public delegate bool Criterion(int x);
    public delegate bool Criter(int x);
    class Program
    {
        static bool IsPositive(int a)
        {
            return (a > 0);
        }
        static bool IsNegative(int a)
        {
            return (a < 0);
        }
        static double MyFunc(double a)
        {
            return (a * a + 2.5);
        }
        public static void ShowFunctionTable(double xn,double xk,double dx,System.Func<double,double> f)//Func f)
        {
            double x = xn;
            while(x<=xk)
            {
                Console.WriteLine(x+"  "+f(x));
                x += dx;
            }
        }
        static void Find(int[] x,Predicate<int> criterion)//Criterion criterion)
        {
            foreach(int xx in x)
                if(criterion(xx))
                    Console.WriteLine(xx);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Sin(x)");
            ShowFunctionTable(-2, 2, 0.5, Math.Sin);
            Console.WriteLine();
            Console.WriteLine("Cos(x)");
            ShowFunctionTable(-2, 2, 0.5, Math.Cos);
            Console.WriteLine();
            Console.WriteLine("x^2+2.5");
            
            ShowFunctionTable(-2, 2, 0.5, MyFunc);
            Console.WriteLine();
            Console.WriteLine("sin(x)/2.5");

            ShowFunctionTable(-2, 2, 0.5, delegate(double x) { return Math.Sin(x) / 2.5; });
            
            Func newFunc = delegate(double a) { if (a > 0) return 1.5; return 5; };
            Console.WriteLine("newFunc="+newFunc(-5));
            int[] arr = { 2, -4, 8, 8,3, -2, 9, 0, -4 };
            Console.WriteLine("Положительные элементы:");
            Find(arr, IsPositive);
            Console.WriteLine("Отрицательные элементы:");
            Find(arr, IsNegative);
            Console.WriteLine("Элементы, которые <3:");
            Find(arr, v=>v<3);
            Array.Sort(arr, ( x,y) => { return -x.CompareTo(y); });
            Find(arr,x=>true);
            Console.ReadKey();
        }
    }
}
