using System;

namespace Task1
{
    internal class Utils
    {
        public static double ReadDouble(string text)
        {
            double result;
            Console.Write(text);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Error.Write("Ошибка ввода, повторите:");
            }
            return result;
        }
    }
}