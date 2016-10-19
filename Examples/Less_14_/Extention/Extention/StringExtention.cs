using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extention
{
    static class StringExtention
    {
        public static string Double(this string s)
        {
            return s + " " + s;
        }

        public static string AddStr(this string s1, string s2, bool b=true)
        {
            if (b)
                return s1 + " " + s2;
            else
                return s2 + " " + s1;
        }
        
    }

    static class HumanExtention
    {
        public static void Show(this Human h,string s)
        {
            Console.WriteLine(h.Name + " " + s);
        }
                public static void Show(this Human h)
        {
            Console.WriteLine(h.Name + " is bad");
        }
    }

    //если класс содержит метод с таким же именем как в другом, будет ругаться, т.к не знает какое именно расширение (метод) использовать
    //static class HumanExtention2
    //{
    //    public static void Show(this Human h)
    //    {
    //        Console.WriteLine(h.Name + " is nyashka");
    //    }
    //}

}
