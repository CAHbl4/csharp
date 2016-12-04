using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            //выделяет память на 4 элемента, по мере необходимости добавляет ещё на 4
            arr.Add(10);
            arr.Add(2);
            arr.Add(9);
            arr.Add(-2);
            arr.Add(15);
            arr.Add(8);
          //  arr.Add("Vasya");
            arr.Sort();       //Vasya не можем сравнить для сортировки с числами
            arr.TrimToSize();   //устанавливает нужную ёмкость
            Console.WriteLine("Ёмкость: "+arr.Capacity+ "; количество элементов: "+arr.Count);

            foreach (object item in arr)
                Console.Write(item + " ");

            int x = 5;
            arr[0] = x;
            // x = arr[0];      //так нельзя
            x = (int)arr[1];

            Console.WriteLine("\nx = arr[1] => "+x);
            foreach (object item in arr)
                Console.Write(item + " ");

            Console.WriteLine("\n>>>>>>>>>>>>>");

            SortedList slist = new SortedList();
            slist.Add(2, 200);
            slist.Add(1, 300);
            foreach (var item in slist.GetKeyList())
                Console.WriteLine(item);
           





            Console.ReadKey();
        }
    }
}
