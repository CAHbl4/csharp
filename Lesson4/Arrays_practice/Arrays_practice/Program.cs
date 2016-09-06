using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 3, 4 };
            var min = from i in arr
                      where i == arr.Min()
                      select i;

            int min2 = arr.Where(x => x == arr.Min()).GetEnumerator().Current;

            Console.WriteLine(min2);
            Console.ReadKey();
        }
    }
}
