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

//*********************************************************************************
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

            //добавление информации - нового узла
            XmlNode newMan = doc.CreateElement("Human"); //создаём узел
            XmlNode elemName = doc.CreateElement("Name");
            XmlNode textName = doc.CreateTextNode("Миша");  //добавляем информацию
            XmlNode elemAge = doc.CreateElement("Age"); //
            XmlNode textAge = doc.CreateTextNode("21");
            XmlNode elemOt = doc.CreateElement("ot");
            XmlNode textOt = doc.CreateTextNode("Ivanovich");

            //собираем узел
            elemName.AppendChild(textName); //добавляем текст в элемент
            elemAge.AppendChild(textAge);   //--//--
            elemOt.AppendChild(textOt);     //добавляем текст в отчество
            elemName.AppendChild(elemOt);   //добавляем отчество в имя

            newMan.AppendChild(elemName); //добавляем элемент в узел (имя и отчество)
            newMan.AppendChild(elemAge);  //--//--
            //добавляем в корень
            doc.DocumentElement.AppendChild(newMan);

            //сохраняем в новый файл
            doc.Save("chel3.xml");

//*********************************************************************************
            //создание нового документа
            XmlDocument doc1 = new XmlDocument();
            XmlNode xmlDec1 = doc1.CreateXmlDeclaration("1.0", "", "");     //1-версия, 2-кодировка по умолчанию не будет добавляться, 3-атрибут не будет добавляться 
            doc1.AppendChild(xmlDec1);      //в декларацию добавим документ
            //создание корневого элемента
            XmlNode root = doc1.CreateElement("ArrayOfHuman");
            doc1.AppendChild(root);
            //создание и добавление узла Human
            //первый чел
            XmlNode newMan1 = doc1.CreateElement("Human"); //создаём узел
            XmlNode elemName1 = doc1.CreateElement("Name");
            XmlNode textName1 = doc1.CreateTextNode("Миша");  //добавляем информацию
            XmlNode elemAge1 = doc1.CreateElement("Age"); //
            XmlNode textAge1 = doc1.CreateTextNode("21");
            XmlNode elemOt1 = doc1.CreateElement("ot");
            XmlNode textOt1 = doc1.CreateTextNode("Ivanovich");
            //второй чел
            XmlNode newMan2 = doc1.CreateElement("Human"); //создаём узел
            XmlNode elemName2 = doc1.CreateElement("Name");
            XmlNode elemAge2 = doc1.CreateElement("Age");
            XmlNode elemOt2 = doc1.CreateElement("ot");
            XmlNode textName2 = doc1.CreateTextNode("Sasha");
            XmlNode textAge2 = doc1.CreateTextNode("32");
            XmlNode textOt2 = doc1.CreateTextNode("Petrovich");
            //собираем первый узел
            elemName1.AppendChild(textName1); //добавляем текст в элемент
            elemAge1.AppendChild(textAge1);   //--//--
            elemOt1.AppendChild(textOt1);     //добавляем текст в отчество
            elemName1.AppendChild(elemOt1);   //добавляем отчество в имя
           
            newMan1.AppendChild(elemName1); //добавляем элемент в узел (имя и отчество)
            newMan1.AppendChild(elemAge1);

            doc1.DocumentElement.AppendChild(newMan1);
            //собираем второй узел
            elemName2.AppendChild(textName2); //добавляем текст в элемент
            elemAge2.AppendChild(textAge2);   //--//--
            elemOt2.AppendChild(textOt2);     //добавляем текст в отчество
            elemName2.AppendChild(elemOt2);   //добавляем отчество в имя

            newMan2.AppendChild(elemName2); //добавляем элемент в узел (имя и отчество)
            newMan2.AppendChild(elemAge2);

            doc1.DocumentElement.AppendChild(newMan2);

            //сохраняем в новый файл
            doc1.Save("chel4.xml");

//*********************************************************************************
            //чтение xml-файла с помощью XmlTextReader
            List<Human> men=new List<Human>();
            XmlTextReader reader = new XmlTextReader("chel4.xml");
            Human currentMan=null;
            while (reader.Read())
            {
                if (reader.NodeType==XmlNodeType.Element)
	            {
                 switch (reader.Name)
                  {
                     case "Human":
                       currentMan = new Human();    //нашли Human и создали currentMan
                       break;
                     case "Name":
                         //дошли до имени и считали
                     //  currentMan.Name = reader.ReadElementContentAsString();
                       //если есть отчество просто считываем что идет за Name
                       reader.Read();
                       currentMan.Name = reader.Value;
                       break;
                     case "Age":
                       //дошли до возраста и считали
                       currentMan.Age = reader.ReadElementContentAsInt();
                         //добавили в men считанного чела
                       men.Add(currentMan); 
                       break;
                  }
	            }
            }
            reader.Close();

            //вывод результата считывания
            foreach (Human item in men)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }

            Console.ReadKey();
        }
    }
}
