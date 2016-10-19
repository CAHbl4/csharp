using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML
{
   public class Human
    {
        //свойство получения имени
        public string Name { get; set; }
        //свойство получения возраста
        public int Age { get; set; }
       //конструктор без параметров
        public Human()  { }
        //конструктор с параметрами
        public Human(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }
}
