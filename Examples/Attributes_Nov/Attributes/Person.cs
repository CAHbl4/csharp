using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [StatusAttribute(ObjectStatus.Vip, IsSecret = false)]      //ObjectStatus.Vip - все объекты этого класса Vip
    [Serializable]      //Serializable - процесс преобразования какого-либо объекта в поток байтов
    [Obsolete("Класс устаревший, лучше использовать класс Human")]  //помечает класс, как устаревший
    [Displayed]
    class Person
    {
        //  [Status(Ordinar)] //уже нельзя использ т.к. наложили ограничение
        public string Fam { get; set; }
        public string Name { get; set; }
        public Person(string fam = "", string name = "")
        {
            Fam = fam;
            Name = name;
        }
        public override string ToString()
        {
            return Fam + " " + Name;
        }

    }
}
