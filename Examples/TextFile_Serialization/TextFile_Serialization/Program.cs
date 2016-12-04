using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace TextFile_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> people = new List<Human>();

            people.Add(new Human { Lastname = "Васечкин", Name = "Петя", Year = 1998 });
            people.Add(new Human { Lastname = "Гоголь", Name = "Коля", Year = 2000 });
            people.Add(new Human { Lastname = "Лукьяненко", Name = "Сергей", Year = 1975 });
            FileStream fs = new FileStream("humans.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs,people);
           
            fs.Close();

            FileStream fstr = File.Open("humans.dat", FileMode.Open);
            BinaryFormatter bfr = new BinaryFormatter();
            List<Human> humans = (List<Human>)bfr.Deserialize(fstr);
            Console.WriteLine("humans.dat");
            foreach (var item in humans)
            {
                Console.WriteLine(item);
            }
            //StreamWriter writer = new StreamWriter("humans.txt");
            //foreach (Human item in people)
            //{
            //   // writer.WriteLine(item.Lastname+" "+item.Name+" "+item.Year);
            //   // writer.WriteLine(item);

            //    writer.Write(item.Year);
            //    writer.Write(";");
            //    writer.WriteLine(item.Name + ";" + item.Lastname);
            //}
            
            //writer.Close();

            List<Human> newPeople = new List<Human>();
            
            using (StreamReader reader = new StreamReader("humans.txt"))
            {
                string[] str;
                
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine().Split(';');
                    newPeople.Add(new Human { Lastname = str[2], Name = str[1], Year = Convert.ToInt32(str[0]) });
                }
            }
            //reader.Close();
            Console.WriteLine("humans.txt");
            foreach (var item in newPeople )
            {
                Console.WriteLine(item);
            }
            //сериализация SOAP
            FileStream fStr = new FileStream("humans.soap", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fStr, people.ToArray<Human>());

            fStr.Close();
            //Десериализация SOAP
            fStr = new FileStream("humans.soap", FileMode.Open);
            Human[] h = (Human[])sf.Deserialize(fStr);
            fStr.Close();
            Console.WriteLine("humans.soap");
            foreach (var item in h)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
