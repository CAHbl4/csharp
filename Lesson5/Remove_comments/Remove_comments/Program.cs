using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Remove_comments
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is comment //123123 \n" +
                          "\"This is not //333\"";
            string pattern = @"^"".*";
            Regex regex= new Regex(pattern);

            foreach (var match in regex.Matches(text))
            {
                Console.WriteLine(match);
            }

            Console.ReadKey();
        }
    }
}
