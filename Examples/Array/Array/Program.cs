using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
           //Massiv array=new Massiv("X",5,-2,5,-1,-2,-1,7);
           //Console.WriteLine(array);
           
           // array[8] = -10;
           
           // for (int i = array.Length - 1; i >= 0;i-- )
           //    Console.WriteLine(array[i]);

           // Console.WriteLine("Левый минимум: "+array.Min()+"  Кол отр после мин="+array.NegativeCountAfterMin());
            

            Console.WriteLine(  "Введите размерность массива ");
            int[] temp = new int[int.Parse(Console.ReadLine())];
            Console.WriteLine("Введите "+temp.Length+" чисел через Enter");
            for (int i = 0; i < temp.Lengt; i++)
            {
                Console.Write(" A["+i+"]=");
                temp[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Нажмите любую клавишу");
            Massiv A = new Massiv("A", temp);
            Console.WriteLine(A);
            Massiv B = new Massiv("B",  -3, 2, -1, 5, -1 );
            Console.WriteLine(B);
            int leftMinB = B.Min();
            int rightMinA = System.Array.LastIndexOf(A.Arr, A.Arr.Min());
            int n = (B.Length - leftMinB - 1)+(A.Length-rightMinA-2);
            int[] temp2 = new int[n];
            System.Array.Copy(B.Arr, leftMinB + 1, temp2, 0, B.Length - leftMinB - 1);
            System.Array.Copy(A.Arr, rightMinA + 1, temp2, B.Length - leftMinB - 1, A.Length - rightMinA-2);
            Massiv C = new Massiv("C",temp2);
            Console.WriteLine(C);

                Console.ReadKey();
        }
    }
}
