using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XML1
{
    class Program
    {
        static bool IsValidFile = true;
        /// <summary>
        ///  метод вычисляет количество положительных элементов
        /// </summary>
        /// <param name="a">исходный массив</param>
        /// <returns>количество положительных элементов</returns>
        /// <exception cref="Exception"/>
        public static int CountPositive(params int[] a)
        {
            int k = 0;
            foreach (int x in a)
            {
                if (x > 0) k++;
                
            }
            return k;
        }
        static void Main(string[] args)
        {
            /*Human man = new Human("Вася", 25);
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
            }*/

            
            //чтение xml-документа с помощью XmlDocument
            XmlDocument doc = new XmlDocument();
            doc.Load("chel2.xml");
            XmlNodeList list = doc.GetElementsByTagName("Human");
            foreach (XmlNode item in list)
            {
                Console.WriteLine(item["Name"].InnerText+"  "+item["Age"].InnerText);
            }
            //добавление нового узла
            XmlNode newMan = doc.CreateElement("Human");
            XmlNode elemName = doc.CreateElement("Name");
            XmlNode elemAge = doc.CreateElement("Age");
            XmlNode textName = doc.CreateTextNode("Миша");
            XmlNode textAge = doc.CreateTextNode("21");
            XmlNode elemOt = doc.CreateElement("Ot");
            XmlNode textOt = doc.CreateTextNode("Иванович");

            elemName.AppendChild(textName);
            elemAge.AppendChild(textAge);
            elemOt.AppendChild(textOt);
            elemName.AppendChild(elemOt);
            newMan.AppendChild(elemName);
            newMan.AppendChild(elemAge);

            doc.DocumentElement.AppendChild(newMan);
            doc.Save("chels3.xml");
            
            //создание нового документа
            XmlDocument doc1 = new XmlDocument();
            //добавление декларации
            XmlNode xmlDecl = doc1.CreateXmlDeclaration("1.0", "", "");
            doc1.AppendChild(xmlDecl);
            
            //создание корневого элемента
            XmlNode root = doc1.CreateElement("ArrayOfHuman");
            doc1.AppendChild(root);

            //создание  и добавление узла Human
            XmlNode newMan1 = doc1.CreateElement("Human");
            XmlNode elemName1 = doc1.CreateElement("Name");
            XmlNode elemAge1 = doc1.CreateElement("Age");
            XmlNode textName1 = doc1.CreateTextNode("Миша");
            XmlNode textAge1 = doc1.CreateTextNode("21");
            XmlNode elemOt1 = doc1.CreateElement("Ot");
            XmlNode textOt1 = doc1.CreateTextNode("Иванович");

            elemName1.AppendChild(textName1);
            elemAge1.AppendChild(textAge1);
            elemOt1.AppendChild(textOt1);
            elemName1.AppendChild(elemOt1);
            newMan1.AppendChild(elemName1);
            newMan1.AppendChild(elemAge1);
            doc1.DocumentElement.AppendChild(newMan1);
            
            //создание  и добавление узла Human
           
            XmlNode newMan2 = doc1.CreateElement("Human");
            XmlNode elemName2 = doc1.CreateElement("Name");
            XmlNode elemAge2 = doc1.CreateElement("Age");
            XmlNode textName2 = doc1.CreateTextNode("Саша");
            XmlNode textAge2 = doc1.CreateTextNode("37");
            XmlNode elemOt2 = doc1.CreateElement("Ot");
            XmlNode textOt2 = doc1.CreateTextNode("Михайлович");

            elemName2.AppendChild(textName2);
            elemAge2.AppendChild(textAge2);
            elemOt2.AppendChild(textOt2);
            elemName2.AppendChild(elemOt2);
            newMan2.AppendChild(elemName2);
            newMan2.AppendChild(elemAge2);
            doc1.DocumentElement.AppendChild(newMan2);
            
            //сохранение в файл
            doc1.Save("chels4.xml");
            
            //чтение xml-файла c помощью XmlTextReader

            List<Human> men=new List<Human>();

            XmlTextReader reader = new XmlTextReader("chels3.xml");
            
            Human currentMan=null;
            
            while(reader.Read())
            {
                if(reader.NodeType==XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Human":
                            {
                                currentMan = new Human();
                                break;
                            }
                        case "Name":
                            {
                                reader.Read();
                                currentMan.Name =reader.Value; 
                                break;   
                            }
                        
                        case "Age":
                            {
                                currentMan.Age = reader.ReadElementContentAsInt();
                                men.Add(currentMan);
                                break;
                            }

                    }
               

                }
            }
            reader.Close();
            Console.WriteLine("чтение с использованием XmlTextReader");
            foreach (var item in men)
            {
                Console.WriteLine(item.Name+"  "+item.Age);
            }

            //проверка файла с книгами на соответствие схеме 
            XmlTextReader readerBooks = new XmlTextReader("..//..//books.xml");
            XmlValidatingReader validater = new XmlValidatingReader(readerBooks);
            validater.Schemas.Add("http://tempuri.org/myBooks.xsd", "..//..//myBooks.xsd");
            validater.ValidationType = ValidationType.Schema;
            bool valid = true;
            try
            {
                while (validater.Read())
                {
                    
                }
            }
            catch (Exception e)
            {

                valid = false;
                Console.WriteLine(e.Message);
            }
            validater.Close();
            if (valid)
            {
                Console.WriteLine("Все ОК");
                XmlDocument docBooks = new XmlDocument();
                docBooks.Load("..//..//books.xml");
                XmlNodeList listBook = docBooks.GetElementsByTagName("book");
                foreach(XmlNode b in listBook )
                    Console.WriteLine(b["author"].InnerText + "  " + b["title"].InnerText + "  " + b["date"].InnerText + "  " + b["pages"].InnerText);
            }
            else
                Console.WriteLine("Файл неправильный!");

            //проверка на соответствие схеме файла с книгами с помощью XmlReader
            Console.WriteLine();
            Console.WriteLine();
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("http://tempuri.org/myBooks.xsd", "..//..//myBooks.xsd");

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schema;
            settings.ValidationEventHandler += ValidationCallBack;

            XmlReader readerBook = XmlReader.Create("..//..//books.xml", settings);
            
            while (readerBook.Read()) ;
            readerBook.Close();
            
            if(IsValidFile)//если файл правильный, читаем и выводим
            {
                XmlTextReader read = new XmlTextReader("..//..//books.xml");
                while (read.Read())
                {
                    if(read.NodeType==XmlNodeType.Element)
                    {
                        switch (read.Name)
                        {
                            case "author":
                                Console.Write(read.ReadElementContentAsString()+"  ");
                                break;
                            case    "title":
                                Console.Write(read.ReadElementContentAsString() + "  ");
                                break;
                            case "date": Console.Write(read.ReadElementContentAsString() + "  ");
                                break;
                            case "pages":
                                Console.WriteLine(read.ReadElementContentAsInt());
                                break;
                            case "book":
                                Console.Write(read.GetAttribute("janre") + "  ");
                                break;
                            
                        }
                    }
                    //else
                    //    if(read.NodeType==XmlNodeType.Attribute)
                    //         Console.Write(read.Name);
                }
                read.Close();
            }
            
            Console.WriteLine(IsValidFile);
            Console.WriteLine(CountPositive(-2,5,-7,4));
            Console.ReadKey();
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Ошибка в xml файле: "+e.Message);
            IsValidFile = false;
        }
    }
}
