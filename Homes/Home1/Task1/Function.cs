using System;

namespace Task1
{
    public class Function
    {
        public Function(double a, double b)
        {
            A = a;
            B = b;
        }

        public double A { get; set; }

        public double B { get; set; }

        public double Result(double x)
        {
            return (1 + Math.Pow(Math.Cos(x + A), 2))/
                   Math.Abs(Math.Pow(x, 3) - 2*Math.Pow(B, 2));
        }

        public void Tabulate(double begin, double end, double step)
        {
            var table = new Table(ToString());
            table.AddColumn("x", 20, Align.Right);
            table.AddColumn("Результат", 20, Align.Right);

            table.DrawHead();

            var cur = begin;
            do
            {
                table.DrawRow(cur.ToString("F"), Result(cur).ToString("E"));
                cur = begin < end ? cur + step : cur - step;
            } while (begin < end ? cur <= end : cur >= end);

            table.DrawFooter();
        }

        public static void Input(out double begin, out double end, out double step)
        {
            do
            {
                begin = Utils.ReadDouble("Введите начало диапазона: ");
                end = Utils.ReadDouble("Введите конец диапазона: ");
                step = Utils.ReadDouble("Введите шаг: ");
            } while (step < 0);
        }

        public override string ToString()
        {
            return "(1+cos(x+1)^2)/abs(x^3-2*2^2)";
        }
    }
}