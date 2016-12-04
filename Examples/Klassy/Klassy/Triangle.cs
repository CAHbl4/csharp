using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassy
{
    class Triangle
    {
        Point v1, v2, v3;
        public Triangle()
        {
            v1 = new Point(1, -1);
            v2 = new Point(0, 0);
            v3 = new Point(1, 1);
        }
        public Triangle(Point p1,Point p2,Point p3)
        {
            v1 = new Point(p1.X,p1.Y);
            v2 = new Point(p2.X, p2.Y);
            v3 = new Point(p3.X, p3.Y);
            
        }
        public Point Top1
        {
            get { return v1; }
        }
        public Point Top2
        {
            get { return v2; }
        }
        public Point Top3
        {
            get { return v3; }
        }
        //свойство - площадь треугольника
        public double Square
        {
            get
            {
                double p = Perimetr / 2;
                return (Math.Sqrt(p * (p - v1.DistanceTo(v2))*(p - v2.DistanceTo(v3))*(p - v3.DistanceTo(v1))));
            }
        }

        //свойство - периметр
        public double Perimetr
        {
            get
            {
                return (v1.DistanceTo(v2)+v2.DistanceTo(v3)+v3.DistanceTo(v1));
            }
        }
        //метод, определяющий вид треугольника
        new public string GetType()
        {
            if (v1.DistanceTo(v2) == v2.DistanceTo(v3) && v2.DistanceTo(v3) == v3.DistanceTo(v1))
                return "равносторонний";
            if (v1.DistanceTo(v2) == v2.DistanceTo(v3) || v2.DistanceTo(v3) == v3.DistanceTo(v1) || v1.DistanceTo(v2) == v3.DistanceTo(v1))
                return "равнобедренный";
            

            return "обычный";
        }
        // статический метод для проверки треугольников на равенство площадей
        public static bool Equals(Triangle t1,Triangle t2)
        {
            if (t1.Square == t2.Square)
                return true;
            return false;
        }
    }
}
