using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human man = new Human("Vasya", 25);
            //Human man1 = new Human("Петя", 25);

            ////создаём объект класса XmlSerializer
            //XmlSerializer serial = new XmlSerializer(typeof(Human));
            ////создаём поток для записи в файл "chel1.xml"
            //using (Stream fStr = new FileStream("chel1.xml", FileMode.Create, FileAccess.Write)) //Create - создаём, Write - записываем
            //{
            //    //сериализуется объект - записывается в поток в формате xml, потому что стр.24
            //    serial.Serialize(fStr, man);
            //}
            //Console.WriteLine("Serialization is end");

            ////десериализация - читаем из потока
            //using (Stream fStr = new FileStream("chel1.xml", FileMode.Open, FileAccess.Read))   //Open - открываем, Read - читаем
            //{
            //    Human vasya = (Human)serial.Deserialize(fStr); //создаём Human и записывем в него из потока
            //    Console.WriteLine(vasya.Name + " " + vasya.Age);
            //}

            ////сериализация коллекции
            //List<Human> men = new List<Human>();
            //men.Add(man);
            //men.Add(man1);
            //XmlSerializer serial1 = new XmlSerializer(typeof(List<Human>));
            //using (Stream fStr1 = new FileStream("chel2.xml", FileMode.Create, FileAccess.Write)) //Create - создаём, Write - записываем
            //{
            //    serial1.Serialize(fStr1, men);
            //}

            ////десериализация коллекции - читаем из потока
            //using (Stream fStr1 = new FileStream("chel2.xml", FileMode.Open, FileAccess.Read))   //Open - открываем, Read - читаем
            //{
            //    List<Human> menRead = (List<Human>)serial1.Deserialize(fStr1); //создаём Human и записывем в него из потока
            //    foreach ( Human item in menRead)
            //    {
            //        Console.WriteLine(item.Name+" "+item.Age);
            //    }
            //}


            //чтение xml-документа с помощью XmlDocument
            XmlDocument doc = new XmlDocument();
            //загрузили документ из файла
            doc.Load("chel2.xml");
            //получаем список всех узлов с именем Human
            XmlNodeList list = doc.GetElementsByTagName("Human");
            //вывод
            foreach (XmlNode item in list)
            {
                Console.WriteLine(item["Name"].InnerText + " " + item["Age"].InnerText);   
            }



            Console.ReadKey();
        }
    }
}
