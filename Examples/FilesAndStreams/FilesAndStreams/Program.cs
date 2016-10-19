using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilesAndStreams
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream f1 = File.OpenRead("f1");
            //FileStream f2 = File.OpenWrite("f2");
            //long p = f1.Length / 2;
            //f1.Seek(p, SeekOrigin.Begin);
            //int b;
            //while ((b=f1.ReadByte())>-1)
            //{
            //    f2.WriteByte((byte)b);
            //}
            
            
            //FileStream f3 = File.OpenRead("f3.txt");
            //f1.Seek(0, SeekOrigin.Begin);
            //long len = Math.Min(f1.Length, f3.Length);
            //long k = 0;
            //int b1;
            //for (int i = 0; i < len; i++)
            //{
            //    b = f1.ReadByte();
            //    b1 = f3.ReadByte();
            //    if(b==b1) k++;
            //}

            //if (f3.Length > f1.Length)
            //    k = k - (f3.Length - f1.Length);
            //Console.WriteLine("процент совпадений:" + k / (double)len * 100 + "%");   
            
            //f1.Close();
            //f2.Close();

            //BinaryWriter br = new BinaryWriter(File.Create("baza.dat"));
            //Console.WriteLine("До записи " + br.BaseStream.Length);
            //br.Write("Иванов"); br.Write(3.56);
            //Console.WriteLine("Иванов " + br.BaseStream.Length);

            //br.Write("Петров"); br.Write(9d);
            //Console.WriteLine("Петров " + br.BaseStream.Length);

            //br.Write("Сидоров"); br.Write(8.2);
            //Console.WriteLine("Сидоров " + br.BaseStream.Length);
            //br.Close();


            //using (BinaryWriter br = new BinaryWriter(File.Open("baza.dat",FileMode.Append)))
            //{

            //    try
            //    {
            //        br.Write("Перельман"); br.Write(10d);

            //        int v = 0;
            //        int c = 5 / v;
            //    }
            //    catch { }
                
            //    br.Write(5);
                
            //}
            using(BinaryReader bReader=new BinaryReader(File.OpenRead("baza.dat")))
            {
                while (bReader.PeekChar() > -1)
                {
                    Console.WriteLine(bReader.ReadString() + "  " + bReader.ReadDouble());
                }
                //Console.WriteLine(bReader.ReadString() + "  " + bReader.ReadDouble());
                //Console.WriteLine(bReader.ReadString() + "  " + bReader.ReadDouble());
            }
            
            using(StreamWriter sr=new StreamWriter(File.OpenWrite("baza.txt")))
            {
                sr.WriteLine("Иванов 3.56");
                sr.Write("Петров "); sr.WriteLine(9);
                sr.WriteLine("{0} {1:f1}", "Сидоров", 8.2565775);
                
            }
            Console.WriteLine("baza.txt ");
            StreamReader reader = new StreamReader("baza.txt");
            string allText = reader.ReadToEnd();
            Console.WriteLine(allText);
            reader.Close();
            Console.ReadKey();
        }
    }
}
