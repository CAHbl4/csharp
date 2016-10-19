using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassy
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание треугольников
            Triangle triangle1 = new Triangle();
            Triangle triangle2 = new Triangle(new Point(2,4),new Point(1,5),new Point(3,7));
            Triangle triangle3 = new Triangle(new Point(1, 4), new Point(2, 2), new Point(2,8));

            //вывод информации в таблицу
            Table table = new Table("Треугольники", 4, new int[] { 8, 20, 20, 25 }, "№ п/п", "Координаты вершин ", "Площадь", "Тип");
            table.TableHead();
            table.TableLine("1", triangle1.Top1 + " " + triangle1.Top2 + " " + triangle1.Top3, triangle1.Square.ToString(), triangle1.GetType());
            table.TableLine("2", triangle2.Top1 + " " + triangle2.Top2 + " " + triangle2.Top3, triangle2.Square.ToString(), triangle2.GetType());
            table.TableLine("3", triangle3.Top1 + " " + triangle3.Top2 + " " + triangle3.Top3, triangle3.Square.ToString(), triangle3.GetType());
            table.TableBottom();

            //сравнение треугольников по площадям
            if(Triangle.Equals(triangle1,triangle2))
                Console.WriteLine("Площади первого  второго треугольников равны");
            else
                Console.WriteLine("Площади первого  второго треугольников не равны");

            Console.ReadKey();
        }
    }
}
