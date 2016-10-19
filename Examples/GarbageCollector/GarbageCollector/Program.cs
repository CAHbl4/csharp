using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestClass t = null;
            //for(int i=0;i<100000;i++)
            //{
            //    t = new TestClass(i);
            //}
            Man p1 = null,p2=null,p3=null;
            //try
            //{
            //     p1 = new Man("Петров");
            //    Console.WriteLine("поколение p1=" + GC.GetGeneration(p1));
                

            //    p2 = new Man("Сидоров");
            //    GC.Collect(0);
            //    Console.WriteLine("поколение p1=" + GC.GetGeneration(p1));
            //    p3 = new Man("Иванов");
            //    Console.WriteLine("Память =" + GC.GetTotalMemory(true));
            //    Console.WriteLine("поколение p1=" + GC.GetGeneration(p1));
            //    throw new Exception("Сбой в системе!");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    p1.Dispose();
            //}
            
            using(p1 = new Man("Петров"))
            {
                Console.WriteLine("поколение p1=" + GC.GetGeneration(p1));
                try
                {
                    throw new Exception("Сбой в системе!");
                }
                catch { }
            }

            p1 = null;
            GC.Collect();
            try
            {
                Console.WriteLine("Память =" + GC.GetTotalMemory(true));
                Console.WriteLine("поколение p3=" + GC.GetGeneration(p3));
                GC.Collect();
                Console.WriteLine("поколение p3=" + GC.GetGeneration(p3));
            }
            catch
            {
                Console.WriteLine("Ошибка "); 
            }
           Console.ReadKey();
        }
    }
}
