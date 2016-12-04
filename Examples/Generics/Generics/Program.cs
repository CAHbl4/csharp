using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> intCollection = new MyCollection<int>(2, 6);
            intCollection.Add(3);
            for(int i=0;i<intCollection.Count();i++)
                Console.WriteLine(intCollection[i]);
            intCollection.Sort();
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine(intCollection[i]);
            int newInt = intCollection.CreateEntity();
            Console.WriteLine("создали число "+newInt);
           
            //коллекция котов
            MyCollection<Cat> catCollection = new MyCollection<Cat>();
            catCollection.Add(new Cat { Name = "Мурка", Weight = 8 });
            catCollection.Add(new Cat { Name = "Мурзик", Weight = 15 });
            catCollection.Add(new Cat { Name = "Барсик", Weight = 10 });
            for (int i = 0; i < catCollection.Count(); i++)
                Console.WriteLine(catCollection[i]);
            
            catCollection.Sort();
            Console.WriteLine("После сортировки:");
            for (int i = 0; i < catCollection.Count(); i++)
                Console.WriteLine(catCollection[i]);

            foreach (Cat cat in catCollection)
                Console.WriteLine(cat);

            Cat newCat = catCollection.CreateEntity();
            Console.WriteLine("Создали кота "+newCat);
            
            DateTime time1 = DateTime.Now;
            ArrayList arrList = new ArrayList();
            for (int i = 0; i < 1000000;i++ )
            {
                arrList.Add(i);//упаковка
                int x =(int) arrList[i];//распаковка
            }
            Console.WriteLine((DateTime.Now-time1).TotalSeconds);
            arrList.Add("Вася");

            DateTime time2 = DateTime.Now;
            List<int> list = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
                int x = list[i];
            }
            //list.Add("Вася");
            Console.WriteLine((DateTime.Now - time2).TotalSeconds);
                Console.ReadKey();
        }
    }
}
