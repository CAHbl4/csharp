using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    class ForSquare : IFigure
    {
        double side;// сторона квадрата
        public ForSquare(double side=0)
        {
            if (side < 0) throw new ArgumentException("Такой квадрат не существует");
            this.side = side;
        }


        public double Square
        {
            get { return side*side; }
        }

        public void ShowInfo()
        {
            Console.WriteLine(" Квадрат со стороной "+side+"  Площадь "+Square);
        }
        public double Perimetr()
        {
            return 4 * side;
        }


        public int CompareTo(object obj)
        {
            IFigure kv=obj as IFigure;
            if (kv != null)
                return this.Square.CompareTo(kv.Square);
            throw new Exception("Не получилось!");
        }
    }
}
