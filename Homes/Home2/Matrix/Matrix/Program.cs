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
            Matrix A = new Matrix(new int[,]
            {
                {1, 2, 3, 4},
                {4, 3, 2, 1},
                {5, 6, 7, 8},
                {8, 7, 6, 5}
            });

            Matrix B = new Matrix(new int[,]
            {
                {1, 1, 1, 1},
                {2, 0, 70, 2},
                {3, 3, 0, 3},
                {4, 4, 4, 4}
            });

            Console.WriteLine("Matrix A:");
            Console.WriteLine(A);

            Console.WriteLine(new String('-',10));

            Console.WriteLine("Matrix B:");
            Console.WriteLine(B);

            if (A.SumPositive() > B.SumPositive())
            {
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        if (B[i, j] == 0)
                            B[i, j] = B.SumDiag;
                    }
                }

                Console.WriteLine("===== Result =====");
                Console.WriteLine("Matrix B:");
                Console.WriteLine(B);
            }
            else
            {
                Console.WriteLine("===== Result =====");
                Console.WriteLine("Sum diag matrix A = " + A.SumDiag);
            }

            Console.ReadKey();
        }
    }
}