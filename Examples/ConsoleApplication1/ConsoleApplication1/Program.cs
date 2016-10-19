using System;
namespace ConsoleApplication1
{
    class Program
    {
        static double Input(string ask)
        {
            Console.WriteLine("Введите число "+ask);
            return double.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
           //ввод исходных данных
            double z=Input("z");
            double x=Input("x");
            double f;
            // вычисление функции
            //if (z > -5 && z <= 0)
            //    f = x * x + z;
            //else
            //    if (z <= -5)
            //        f = 2.5 * z;
            //    else
            //        f = (x * x * x + 1.3) / z;

            f = (z > -5 && z <= 0) ? x * x + z : ((z <= -5) ? (2.5 * z) : ((x * x * x + 1.3) / z));
           
            // вывод результата
            Console.WriteLine("\tx={0,5:f2} z={1,5:f2}   f={2}",x,z,f);
            
            Console.ReadKey();
        }
    }
}
