using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class  Human
    {
        protected string fam, status;
        protected int year;
        public Human(string fam="",string status="",int year=0)
        {
            this.fam = fam;
            this.status = status;
            this.year = year;
        }
        public string Status
        { 
            get { return status; } 
        }
        //public static void Info()
        //{
        //    Console.WriteLine("fgfhfgf");
        //}
        public void Info()
        {
            Console.WriteLine(fam + "  " + status + " " + year+"  "+SrBall());
        }
        abstract public double SrBall();
        public void Info(string title)
        {
            Console.WriteLine(title+"  "+fam + "  " + status + " " + year);
        }

    }
}
