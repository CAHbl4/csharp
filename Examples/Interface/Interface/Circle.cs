using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Circle:IFigure
    {
        double radius;
        ConsoleColor color;
        public Circle(double radius=0,ConsoleColor color=ConsoleColor.Blue)
        {
            if (radius < 0) throw new ArgumentException(" Невозможный круг");
            this.radius = radius;
            this.color = color;
        }


        public double Square
        {
            get { return Math.PI*radius*radius; }
        }

        public void ShowInfo()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor=color;
            Console.WriteLine(" Круг с радиусом " + radius + " площадь=" + ((IFigure)this).Square);
            Console.ForegroundColor = temp;
        }

        public int CompareTo(object obj)
        {
            IFigure kv = obj as IFigure;
            if (kv != null)
                return this.Square.CompareTo(kv.Square);
            throw new Exception("Не получилось!");
        }
    }
}
