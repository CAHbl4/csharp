using System;
using Task1;

namespace Task2
{
    internal static class Program
    {
        private static void Main()
        {
            Fraction[] fractions =
            {
                new Fraction(),
                new Fraction(7, 4),
                new Fraction(-8, 12),
                new Fraction(1, 10)
            };
            Table table = new Table();
            table.AddColumn("№ п/п", 5, Align.Left);
            table.AddColumn("Дробь", 15, Align.Left);
            table.AddColumn("Десятичная дробь", 20, Align.Right);

            table.DrawHead();
            for (int i = 0; i < fractions.Length; i++)
            {
                table.DrawRow((i + 1).ToString(), fractions[i].ToString(), fractions[i].Double.ToString());
            }
            table.DrawFooter();

            Table table2 = new Table();

            table2.AddColumn("Дробь", 15, Align.Left);
            table2.AddColumn(fractions[3] + " + n", 15, Align.Left);
            table2.AddColumn(fractions[3] + " - n", 15, Align.Left);
            table2.AddColumn(fractions[3] + " * n", 15, Align.Left);

            table2.DrawHead();
            for (int i = 0; i < fractions.Length - 1; i++)
            {
                table2.DrawRow(
                    fractions[i].ToString(),
                    Fraction.Add(fractions[3], fractions[i]).ToString(),
                    Fraction.Sub(fractions[3], fractions[i]).ToString(),
                    Fraction.Mult(fractions[3], fractions[i]).ToString()
                    );
            }
            table2.DrawFooter();

            Console.ReadKey();
        }
    }
}