using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                double a = ReadDouble("Введите значение a: ");
                double x1 = ReadDouble("Введите начальное значение x: ");
                double x2 = ReadDouble("Введите конечное значение x: ");
                double step = ReadDouble("Введите шаг x: ");
                for (double i = x1; i <= x2; i+=step)
                {
                    Console.WriteLine("{0,5:F3}\t{1,5:F3}",i,Func1(a,i));
                }

                double z = ReadDouble("Введите значение z: ");
                double x = ReadDouble("Введите значение x: ");
                Console.WriteLine("Результат работы Func2: " + Func2(x,z));


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

        private static double Func1(double a, double x)
        {
            return (x + Math.Pow(a, 2))/a*1.4 - x;
        }

        private static double Func2(double x, double z)
        {
            if (z < 0 || z > -5)
            {
                return x*x + z;
            }
            if (z <= -5)
            {
                return z*2.5;
            }
            return (x*x*x + 1.3)/z;
        }

        private static double ReadDouble(string s)
        {
                Console.Write(s);
                return double.Parse(Console.ReadLine());
        }
    }
}
