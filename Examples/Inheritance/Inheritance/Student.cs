using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Student:Human
    {
        int math, phys, hist;
         //new public string Info { get; set; }
        public Student(string fam, int year, int m, int p, int h)
            : base(fam, "студент", year)
        {                        
            math = m;
            phys = p;
            hist = h;
        }
         public override double SrBall()
        {

            return (math + phys + hist) / 3f;
        }
        new  public void Info()
        {
            base.Info();
            Info("ghgjg");
            Console.WriteLine("оценки за сессию: " + math + "  " + phys + "  " + hist);
        }
    }
}
