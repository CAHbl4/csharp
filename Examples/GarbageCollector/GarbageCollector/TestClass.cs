using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class TestClass
    {
        int x;
        public TestClass(int x)
        {
            this.x = x;
            Console.WriteLine("Создан объект "+x);
        }
         ~TestClass()
        {
            Console.WriteLine("Уничтожен "+x);
            //Console.ReadKey();
        }
    }
}
