using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Исключения
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
                int a = 1 ;
                double y, b;
                try
                {

                    b = 0;
                    if (b == 0) throw new MyException("Деление на нуль для вещественных чисел",DateTime.Now);
                    else
                        y = a / b;
                    Console.WriteLine(y);
                }
                catch (DivideByZeroException f)
                {
                    Console.WriteLine(f.Message);
                }


                catch (OverflowException f)
                {
                    Console.WriteLine("Наверно, очень большое число..." + f.Message);
                }
                catch (FormatException f)
                {
                    Console.WriteLine("Что-то не так..." + f.Message);
                }
                catch (MyException f)
                { 
                    Console.WriteLine(f.Message+" Это наше исключение!!!  "+f.TimeOfError); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                checked
                {
                    int x = 567;
                    byte bb = (byte)x;
                    Console.WriteLine(bb);
                }
            Console.ReadKey();
        }
    }
}
