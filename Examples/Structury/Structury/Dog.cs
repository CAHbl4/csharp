using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structury
{
    struct Dog
    {
         string breed;
        public int Height;
        public static string name;
        public Dog(string type, int height=6)
        {
            breed = type;
            Height = height;
        }
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        static Dog()
        {
            name = "Жучка";
            Console.WriteLine("РАБОТАЕТ ОМОН");
        }
        public string GetBreeed()
        {
            return "Порода" + breed;
        }
    }
}
