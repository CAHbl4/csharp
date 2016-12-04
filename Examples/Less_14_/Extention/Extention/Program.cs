using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extention
{
    struct Dog
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            Dog? d = new Dog(); //идентично Nullable<Dog> y = null;
            Nullable<Dog> y = null;
            Console.WriteLine(d.HasValue);  //true если d!=null

            int z = x ?? 30;    //если х null z=30 иначе z=х
            Console.WriteLine(z);
            x = 100;
            z = x ?? 30;
            Console.WriteLine(z);

            //расширение класса строк
            Console.WriteLine("^^^^^^^^^^^^");
            string str = "Vasya";
            Console.WriteLine(str.Double());
            Console.WriteLine(StringExtention.Double(str));

            Console.WriteLine("^^^^^^^^^^^^");
            Console.WriteLine(str.AddStr("Olga"));
            Console.WriteLine(StringExtention.AddStr(str,"Katya",false));

            Console.WriteLine("^^^^^^^^^^^^");
            Human man = new Human { Name = "Gorge" };
            man.Show();
            man.Show("is good man");

            HumanExtention.Show(man);

            




            Console.ReadKey();
        }
    }
}
