using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML1
{
    public class Human
    {
        [XmlAttribute]
        public string Name { get; set; }
        public int Age { get; set; }
        public Human()
        {

        }
        public Human(string name="",int age=0)
        {
            Name = name;
            Age = age;
        }
    }
}
