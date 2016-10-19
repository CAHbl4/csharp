using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Human
    {
        public const int NoseCount=1;
        public static string Color;
        public readonly int EarsCount;
        string name;
        public Human():this("Ваня",1)
        {

        }
        public Human(string name="",int earsCount=2)
        {
            this.name = name;
            EarsCount = earsCount;
        }
        //свойство доступа 
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void SetName(string name="Ваня")
        {
            this.name = name;
        }
       override  public string  ToString()
        {
            return name + " количество ушей: " + EarsCount+"  цвет волос: "+Color;
        }
       static Human()
       {
           Console.WriteLine("Работает омон");
           Color = "blond";
       }
       ~ Human()
       {
           Console.WriteLine("Уничтожен "+name);
       }
    }
}
