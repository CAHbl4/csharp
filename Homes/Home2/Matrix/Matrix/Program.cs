using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix();
            Matrix m2 = new Matrix(
            new int[4,4]
            {
                {-1,-2,-3,4},
                {4,3,2,1},
                {5,6,7,8},
                {8,7,6,5}
            });

            Console.WriteLine(m1 + "\n");
            Console.WriteLine(m2);

            Console.WriteLine(m1.SumDiag);

            Console.ReadKey();

        }
    }
}
