using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {

            
            try
            {
                Circle krug = new Circle(3, ConsoleColor.Red);
                
                IFigure kvadrat = new ForSquare(5);
                
                Figures f = new Figures(krug, kvadrat,new Circle(6),new ForSquare(4));

                Console.WriteLine("Foreach");
                foreach (IFigure ff in f)
                    ff.ShowInfo();

                Console.WriteLine("Foreach через один");
                foreach (IFigure ff in f.ByTwo())
                    ff.ShowInfo();
                
                Console.WriteLine("Foreach в обратном порядке");
                foreach (IFigure ff in f.Back())
                    ff.ShowInfo();

                Console.WriteLine("For");
                for (int i = 0; i < f.Count; i++)
                    f[i].ShowInfo();

                f.Sort();
                Console.WriteLine();
                for (int i = 0; i < f.Count; i++)
                    f[i].ShowInfo();

                f.Sort(new ComparerByType());
                Console.WriteLine();
                for (int i = 0; i < f.Count; i++)
                    f[i].ShowInfo();
            }
            catch(ArgumentException e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
