using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Show(string name="Вася",int age=25)
        {
            Console.WriteLine("Имя "+name+"  возраст "+age);
        }
        static void PlusFive(ref int x)
        {
            x = x + 5;
        }
        static void ChangeHuman(Human man)
        {
            man.SetName("Кузя");
        }
        static void Change(int x,out int? y)
        {
            y = x + 3;
        }
        static void Main(string[] args)
        {

            Human ivanov = new Human();
            System.Console.WriteLine(Human.NoseCount);
            //Human.Color = "red";
            Human petrov = new Human("Вася");
            ivanov.Name = 2.ToString();
            Console.WriteLine(ivanov.Name);
            Console.WriteLine(ivanov+" \n "+petrov);
            //petrov.EarsCount = 3;
            //petrov.name = "DFGFD";
            petrov.SetName();
            //Show(age:12);
            //int a=6;
            //PlusFive(ref a);
            //Console.WriteLine("a="+a);
            //int? c=0;
            //Change(a, out c);
            //Console.WriteLine(c);
            ChangeHuman(petrov);
            Console.WriteLine(petrov);
            Human h=null;
            Console.WriteLine(h);
            //c = null;
            //c = 2 * 3;
            Console.ReadKey();
        }
    }
}
