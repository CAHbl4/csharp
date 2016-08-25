using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassivyObjectov
{
    class Program
    { 
        static int Compare(Object o1,Object o2)
        {
            Film f1=null;
            if(o1 is Film)
               f1 = (Film)o1;
            //Film f2 = (Film)o2;
            Film f2 = o2 as Film;
            if(f2!=null)
            {
            if (f1.Genre == f2.Genre)
                return 0;
            if (f1.Genre.CompareTo(f2.Genre) == 1)
                return -1;
            return 1;
            }
            return 0;
            //return f1.Genre.CompareTo(f2.Genre);
        }
        static void Main(string[] args)
        {
            //	формирует массив объектов класса «Фильм» (при создании объекта в конструктор передавать константы, т.е. не нужно вводить с клавиатуры или из файла поля класса); 
            Film[] films = new Film[4];
            films[0] = new Film("Такси", "Люк Бессон", "комедия", new decimal[] { 300, 300, 200, 100 }, 150);
            films[1] = new Film("Красотка", "Спилберг", "мелодрама", new decimal[] { 100 }, 350);
            films[2] = new Film("Елки", "Светлаков", "комедия", new decimal[] { 50, 30, 20, 10 }, 0);
            films[3] = new Film("Аватар", "Кэмерон", "фантастика", new decimal[] { 800, 200 }, 15);
            
            //	выводит на экран всю информацию 
            Table table = new Table("Фильмы", 4, new int[] { 15, 15, 15, 15 }, "Название", "Режиссер", "жанр", "Затраты");
            table.TableHead();
            foreach (Film f in films)
                table.TableLine(f.Title, f.Director, f.Genre, f.GetSumCost().ToString());
            table.TableBottom();

            //–	определяет суммарные затраты на съемку комедий  и мелодрам
            decimal sum=0;
           // for (int i = 0; i < films.Length;i++ )
                foreach (Film f in films)
                    if (f.Genre == "комедия" || f.Genre == "мелодрама")
                        sum += f.GetSumCost();
            Console.WriteLine("Cуммарные затраты на съемку комедий  и мелодрам = "+sum);
            //–	сортирует фильмы по жанрам 
            Array.Sort(films,Compare);
            Table table1 = new Table("Фильмы", 4, new int[] { 15, 15, 15, 15 }, "Название", "Режиссер", "жанр", "Затраты");
            table1.TableHead();
            foreach (Film f in films)
                table1.TableLine(f.Title, f.Director, f.Genre, f.GetSumCost().ToString());
            table1.TableBottom();

            Console.ReadKey();
        }
    }
}
