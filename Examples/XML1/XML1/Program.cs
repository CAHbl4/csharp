using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML1
{
    class Program
    {
        static void Main(string[] args)
        {
            Human man = new Human("Вася", 25);
            Human man1 = new Human("Петя", 20);
            
            
            XmlSerializer serializer = new XmlSerializer(typeof(Human));

            using(Stream  fStr=new FileStream("chel1.xml",FileMode.Create,FileAccess.Write))
            {
                serializer.Serialize(fStr, man);//сериализация объекта man в файл в формате XML
                
            }
            Console.WriteLine("Сериализация завершена");
            //десериализация
            //using (Stream fStr = new FileStream("chel1.xml", FileMode.Open, FileAccess.Read))
            //{
            //    Human vasja =(Human) serializer.Deserialize(fStr);
            //    Console.WriteLine(vasja.Name+"  "+vasja.Age);
            //}

            //сериализация коллекции
            List<Human> men = new List<Human>();
            men.Add(man);
            men.Add(man1);
            XmlSerializer serial = new XmlSerializer(typeof(List<Human>));
            using (Stream fStr = new FileStream("chel2.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fStr, men);//сериализация объекта man в файл в формате XML
            }
            Console.ReadKey();
        }
    }
}
