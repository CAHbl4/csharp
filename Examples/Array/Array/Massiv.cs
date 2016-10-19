using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Massiv
    {
        int[] arr; //закрытое поле-массив
        string name;//закрытое поле-имя массива
        //public Massiv()
        //{
        
        //}
        public Massiv(string name,params int[] arr )
        {
            this.name = name;
            this.arr = new int[arr.Length];
            arr.CopyTo(this.arr, 0);
        }
        //свойство - длина массива
        public int Length 
        {
            get { return arr.Length; } 
        }
        public override string ToString()
        {
            string str = "Исходный массив " + name+"\n";
            foreach (int x in arr)
                str = str + " " + x;
            return str;
        }

        //cвойство для доступа к полю arr
        public int[] Arr
        {
            get { return arr; }
            set { arr = value; }
        }
        // одномерный индексатор
        public int this[int i]
        {
            get { return arr[i]; }
            set { if(i<Length) arr[i] = value; }
        }


        //метод для поиска левого минимума в массиве
        public int Min()
        {

            int min = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[min]) min = i;
            }
            return min;
            
                //System.Array.IndexOf(arr, arr.Min());
        }
        //метод, который определяет количество отрицательных чисел после минимума
        public int NegativeCountAfterMin()
        {
            int k = 0;
            for (int i = Min()+1; i < Length; i++)
            {
                if (arr[i] < 0) k++;
 
            }
            return k;
        }
    }
}
