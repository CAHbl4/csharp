using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structury
{
    public enum DogBreed { Ovcharka=35,Taksa,Rotvejler=40}
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = Convert.ToDateTime("12.09.2016 14:50");
            Console.WriteLine(data+"  "+data.Day+"  "+data.Date+"  день недели "+data.DayOfWeek);
            
            Console.WriteLine(DateTime.Now.DayOfWeek);
            Console.WriteLine(DateTime.Now.TimeOfDay);
            Console.WriteLine(DateTime.IsLeapYear(2016));
            TimeSpan ts = new TimeSpan(10, 2, 0, 0);
            Console.WriteLine(DateTime.Now.Add(ts));// добавление промежутка времени
            data = data + TimeSpan.FromDays(5);

            //for(DogBreed db=DogBreed.Ovcharka;db<=DogBreed.Rotvejler;db++)
            //    Console.WriteLine(db);
            
            string[] breeds = Enum.GetNames(typeof(DogBreed));
            foreach(string b in breeds)
                Console.WriteLine(b);
            
            foreach (int b in Enum.GetValues(typeof(DogBreed)))
                Console.WriteLine(b);

            Console.ReadKey();
        }
    }
}
