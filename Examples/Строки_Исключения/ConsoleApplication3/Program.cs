using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<s>\w\w).{2,}?\k<s>\b";
            string input = "  asa23AFas  33 45 AFfd34$fsf2999AF sgfhsgdfjhgfj AFsdfsdfdAF \t 79   77";
            Regex regex = new Regex(pattern);
            foreach(Match m in regex.Matches(input))
                Console.WriteLine(m);
            string output = Regex.Replace(input, pattern, "ВАСЯ");
            string outputWithoutWhitespace = (new Regex("\\s+")).Replace(input, " ");
            Console.WriteLine(output);
            Console.WriteLine(outputWithoutWhitespace);
            string inp = "2016 1956 2001 1817  2013";
            string p = @"(?<=(\b20))\d\d";
            foreach(Match m in Regex.Matches(inp,p))
                Console.WriteLine(m);
            string news = (new Regex(@"\b\w*\d+\w*\b")).Replace(input, @"($&)");
            Console.WriteLine(news);
            Console.ReadKey();
        }
    }
}
