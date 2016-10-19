using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files
{
    class Program
    {
        static void BuildDirectories(string space,DirectoryInfo d)
        {
            
            // space - отступ при выводе папок внутри папки d 
            //просмотр папок
            foreach(DirectoryInfo curDir in d.GetDirectories())
            {
                Console.WriteLine(space +" Папка: "+curDir.Name);
                BuildDirectories(space + "  ", curDir);//рекурсивный вызов метода для вывода папок из папки curDir, при этом отступ увеличивается 
            }
            // вывод файлов из папки d
            foreach (var file in d.GetFiles())
            {
                Console.WriteLine(space+"Файл: "+file.Name);
            }
        }
        static void Main(string[] args)
        {
            //File.Create("File1.dat").Close();
            Console.SetBufferSize(100, 2000);// устанавливаем размер буфера консоли, чтобы все поместилось
            File.WriteAllText("File1.dat", "Привет, Вася");
            
            Console.WriteLine(File.GetCreationTime("File1.dat") + "  " + File.GetAttributes("File1.dat"));
            
            File.Copy("File1.dat", "File2.dat",true);
            
            File.SetAttributes("File1.dat", File.GetAttributes("File1.dat") | FileAttributes.Hidden);
            
            Console.WriteLine(File.GetCreationTime("File1.dat") + "  " + File.GetAttributes("File1.dat"));

            File.SetAttributes("File1.dat", File.GetAttributes("File1.dat") ^ FileAttributes.Hidden);
            
            Console.WriteLine(File.GetCreationTime("File1.dat") + "  " + File.GetAttributes("File1.dat"));
            //File.Delete("File1.dat");

            //использование FileInfo
            FileInfo f = new FileInfo("File4.dat");
            //if (!f.Exists)  // ? Проверить!
            //{
                f.Create().Close();

            //}
            Console.WriteLine("Атрибуты: " + f.Attributes + " папка: " + f.DirectoryName + " размер " + f.Length);
            f.CopyTo("File3.dat",true);
            
            //Работа с папками
            DirectoryInfo d = new DirectoryInfo(@"e:\ОБМЕН\_П11015\С#_Романькова\Теория");
            FileInfo[] files = d.GetFiles("*.ppt",SearchOption.AllDirectories);
            foreach(FileInfo file in files)
            {
                Console.WriteLine(  file.Name);
            }

            DirectoryInfo dir = new DirectoryInfo(@"e:\ОБМЕН\_П11015\С#_Романькова");
            Console.WriteLine(@"e:\ОБМЕН\_П11015");
            BuildDirectories("  ",dir);
            Console.ReadKey();
        }
    }
}
