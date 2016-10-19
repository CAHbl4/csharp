using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peregruzka_operacij
{
    class Fraction
    {
        //числитель
        public int Numerator
        { get; set; }
        
        //знаменатель
        public int Denumerator
        { get; set; }
        //конструктор
        public Fraction(int numerator=1,int denumerator=2)
        {
            Numerator = numerator;
            Denumerator = denumerator;
        }
        public override string ToString()
        {
            return (Numerator+"/"+Denumerator);
        }
        // оператор унарный минус
        public static Fraction operator -(Fraction f)
        {
            return new Fraction(-f.Numerator, f.Denumerator);
        }
        //оператор true
        public static bool operator true(Fraction f)
        {
            if (f.Denumerator != 0)
                return true;
            return false;
        }
        public static bool operator false(Fraction f)
        {
            //if (f.Denumerator == 0)
                return true;
            //return false;
            
        }
        // операция умножения 
        public static Fraction operator *(Fraction f1,Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denumerator * f2.Denumerator);
        }
        public static Fraction operator *(int f1, Fraction f2)
        {
            return new Fraction(f1 * f2.Numerator,  f2.Denumerator);
        }
        public static Fraction operator *(Fraction f2, int f1)
        {
            return f1*f2;
        }



        // операция &
        public static Fraction operator &(Fraction f1,Fraction f2)
        {
            //if (f1.Denumerator != 0 && f2.Denumerator != 0)
            //    return true;
            //return false;
            //return (f1.Denumerator != 0 && f2.Denumerator != 0);
            if (f1)
                if (f2)
                    return new Fraction();
            return new Fraction(1,0);
        }
        // явная операция преобразования дроби в число
        public static explicit operator double(Fraction f)
        {
            return f.Numerator / (Double)f.Denumerator;
        }

        // неявная операция преобразования целого числа в дробь
        public static implicit operator Fraction(int x)
        {
            return new Fraction(1, x);
        }
    }
}
