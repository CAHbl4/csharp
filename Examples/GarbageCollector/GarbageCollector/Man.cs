using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Man:IDisposable
    {
        string fam;
        int[] x;
        public Man(string fam)
        {
            this.fam = fam;
            x = new int[10000];
            for(int i=0;i<10000;i++)
            {
                x[i] = i;
            }
        }
        ~Man()
        {
            Console.WriteLine("Уничтожен "+fam);
            Console.ReadKey();
        }

        public void Dispose()
        {
            Console.WriteLine("Уничтожается "+fam);
            GC.SuppressFinalize(this);
        }
    }
}
