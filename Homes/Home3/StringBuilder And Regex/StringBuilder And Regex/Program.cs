using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StringBuilder_And_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            //В тестовой строке из задания заменил символы в первых двух "ах" на кирилицу
            string testString =
                "Мама, ах ах,, мыла   раму 25/05/2015 ух;25раз!!!  Потом  26/05/2015 смотрела, ох  долго, фх,фх Дом2!...  Без хх труда не выловишь и рыбку из пруда?!! 27/05/2015 она ых отдыхала...";
            StringBuilder result = new StringBuilder();
            string splitSentences = @"[.!?]+";
            string splitWords = @"([ ,;]*[а-яА-Я]{1}[хХ]{1}[ ,;]*)+|[ ,;]+";
            string matchDate = @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)[0-9]{2}";
            string matchWordsWithNumbers = @"[^ ]*\d[^ ]*";
            string replaceMatch = @"($&)";

            try
            {
                string[] sentences = Regex.Split(testString, splitSentences);
                foreach (string sentence in sentences)
                {
                    string[] words = Regex.Split(sentence, splitWords);
                    if (words.Length > 3 && Regex.IsMatch(sentence, matchDate))
                        result.Append(words[words.Length - 2] + " " + words[words.Length - 1] + " ");
                }
                string tmp = Regex.Replace(result.ToString(), matchWordsWithNumbers, replaceMatch);
                result.Clear().Append(tmp);
                Console.WriteLine(result);
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}