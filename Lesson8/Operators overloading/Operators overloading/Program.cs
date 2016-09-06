using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Operators_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass t1 = new TestClass();
            t1.A = 3;
            Console.WriteLine(t1);
            t1++;
            Console.WriteLine(++t1);

            int x = 5;
            Console.WriteLine("x: {0}", x++);
            Console.WriteLine("x: {0}", ++x);
            
        }

    }
}
