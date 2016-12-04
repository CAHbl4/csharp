using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFile_Serialization
{
    [Serializable]
    class Human
    {
        public string Lastname { get; set; }
        public string Name { get; set; }
        //[NonSerialized]
        int year;
        public int Year 
        { 
            get{return year;}
            set { year = value; }
        }
        public override string ToString()
        {
            return Name+" "+Lastname+"  "+Year;
        }
    }
}
