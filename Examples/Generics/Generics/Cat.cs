using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Cat:IComparable<Cat>
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return Name+"  "+Weight;
        }
        public Cat(string name = "", int weight = 10)
        {
            Name = name;
            Weight = weight;
        }
        public Cat()
        {

        }
        //public int CompareTo(object obj)
        //{
        //    Cat cat=obj as Cat;
        //    return (this.Weight.CompareTo(cat.Weight));
        //}

        public int CompareTo(Cat other)
        {
            return (this.Weight.CompareTo(other.Weight));
        }
    }
}
