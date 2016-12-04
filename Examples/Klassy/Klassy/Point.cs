using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassy
{
    class Point
    {
        // поле  - ордината точки
        double y;
        //автоматическое свойство - абсцисса точки
        public double X
        { get; set; }
        
        //свойство для доступа к полю у
        public double Y
        {
            get { return y; }
             
        }
        //конструктор c параметрами
        public Point(double x=1,double y=1)
        {
            X = x;
           // this.y = y;
            this.y = y;
            
        }
        //конструктор по умолчанию
        //public Point():this(1,1)
        //{
            
        //}
        //метод для вычисления расстояния от текущей точки до заданной точки p

        public double DistanceTo(Point p)
        {
            return (Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - this.Y, 2)));
        }

        //переопределение метода ToString
        public override string ToString()
        {
            return "("+X+";"+Y+")";
        }
    }
}
