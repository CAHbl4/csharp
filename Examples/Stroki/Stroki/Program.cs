using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Stroki
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b\d{1,2}([/.])\d{2}\1\d{4}\b";
            Regex regex = new Regex(pattern);
            string input = "Кит 12/05/2016 чем кот 12.01.2016 , а кOт хитрее 35/12/2000 китов. 15/12.2016";
            if (regex.IsMatch(input))
            {
                Match m = regex.Match(input);
                while (m.Success)
                {
                    try
                    {
                        DateTime d = Convert.ToDateTime(m.ToString());
                        Console.WriteLine("Нашли! " + m);
                    }
                    catch { Console.WriteLine("Нашли неправильную дату! " + m); };
                    m = m.NextMatch();
                }
            }
            else
                Console.WriteLine(":-(");
            Console.WriteLine("Найденные даты, соответствующие шаблону");
            MatchCollection matchs = regex.Matches(input);
            foreach(Match mch in matchs )
                Console.WriteLine(mch);

            string input1 = "аxВася, аx, пошел yx в кино! zx Ура!";
            Regex rg = new Regex(@"[, !?.]*([a-zA-Z]x)+");//Неправильно!!
            string[] ss = rg.Split(input1);
            foreach(string s in ss)
                Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
