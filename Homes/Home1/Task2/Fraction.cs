using System;
using System.Text;

namespace Task2
{
    class Fraction
    {
        private int numerator = 1;
        private int denominator = 2;


        public Fraction() {}

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            Denominator = denominator;
        }


        public int Numerator
        {
            set
            {
                numerator = value;
                Reduce();
            }
        }

        public int Denominator
        {
            set
            {
                if (value > 0)
                {
                    denominator = value;
                    Reduce();
                }
                else throw new ArgumentException("Denominator should be greater than 0");
            }
        }

        public double Double
        {
            get { return (double) numerator / denominator; }
        }

        public static Fraction Add(Fraction left, Fraction right)
        {
            Fraction result = new Fraction(left.numerator, left.denominator);
            int lcd = LCD(result.denominator, right.denominator);
            result.numerator = result.numerator * lcd / result.denominator;
            result.numerator += right.numerator * lcd / right.denominator;
            result.denominator = lcd;
            result.Reduce();
            return result;
        }

        public static Fraction Sub(Fraction left, Fraction right)
        {
            return Add(left, new Fraction(-right.numerator, right.denominator));
        }

        public static Fraction Mult(Fraction left, Fraction right)
        {
            Fraction result = new Fraction(left.numerator, left.denominator);
            result.numerator *= right.numerator;
            result.denominator *= right.denominator;
            result.Reduce();
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (numerator != 0)
            {
                int integer = numerator / denominator;
                int remainder = numerator % denominator;
                if (integer != 0)
                {
                    result.Append(integer);
                    if (remainder != 0)
                        result.Append('+');
                }
                if (remainder != 0)
                {
                    result.Append(integer != 0 ? Math.Abs(remainder) : remainder);
                    result.Append("/" + denominator);
                }
            }
            else result.Append("0");
            return result.ToString();
        }

        private static int LCD(int left, int right)
        {
            int lcd = left > right ? left : right;
            while (lcd % left != 0 || lcd % right != 0)
                ++lcd;
            return lcd;
        }


        private static int GCD(int left, int right)
        {
            while (right != 0)
            {
                int tmp = right;
                right = left % right;
                left = tmp;
            }
            return left;
        }


        private void Reduce()
        {
            int gcd = GCD(numerator, denominator);
            numerator = numerator / gcd;
            denominator = denominator / gcd;
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }
    }
}