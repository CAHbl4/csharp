using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Status(ObjectStatus.Vip,IsSecret=false)]
    [Serializable]
    [Obsolete("Класс устарел, лучше использовать класс Human")]
    [Displayed]
    class Person
    {
       
        public string Fam { get; set; }
        public string Name { get; set; }

        public Person(string fam="",string name="")
        {
            Fam = fam;
            Name = name;
        }
        public override string ToString()
        {
            return Fam+"  "+Name;
        }
    }
}
