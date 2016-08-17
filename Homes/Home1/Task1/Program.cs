using System;

namespace Task1
{
    internal static class Program
    {
        private static void Main()
        {
            var f1 = new Function(Utils.ReadDouble("Введите a: "), Utils.ReadDouble("Введите b: "));
            Console.WriteLine("Результат для x = 1 : " + f1.Result(1));
            Console.WriteLine("Результат для x = 2 : " + f1.Result(2));
            Console.WriteLine("Результат для x = 3 : " + f1.Result(3));

            var f2 = new Function(Utils.ReadDouble("Введите a: "), Utils.ReadDouble("Введите b: "));
            Console.WriteLine("Результат для x = 1 : " + f2.Result(1));
            Console.WriteLine("Результат для x = 2 : " + f2.Result(2));
            Console.WriteLine("Результат для x = 3 : " + f2.Result(3));

            double begin, end, step;
            Function.Input(out begin, out end, out step);
            f1.Tabulate(begin, end, step);
            f2.Tabulate(begin, end, step);
        }
    }
}