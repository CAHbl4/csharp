using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human h = new Human("Иванов",year:2005);
            Human stud = new Student("Петров", 1997, 8, 9, 8);
            //stud.Info();
            ListnerITShag listner = new ListnerITShag(" Матузов ", 2000, "П11015");
            //listner.Info();
            Human[] humans = { stud, listner, new ListnerITShag(" Рипинский ", 1999, "П11015"), new Student("Пучачева", 1919, 10, 10, 10) };
            foreach (Human h in humans)
            {
                h.Info();
                //if (h.Status == "слушатель АйТиШаг")
                //if (h is ListnerITShag)
                //if(h.GetType() == typeof(ListnerITShag))
                // Console.WriteLine(
                //    ((ListnerITShag)h).group);
                ListnerITShag l = h as ListnerITShag;
                if(l!=null)
                    Console.WriteLine(l.group);
            }
            Console.ReadKey();
        }
    }
}
