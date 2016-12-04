using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        static void BaseColor()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LightColor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        static void ShowMenuItem(int itemIndex,string item)
        {
            Console.SetCursorPosition(25, 8 + itemIndex);
            Console.WriteLine(item);
        }
        static void Main(string[] args)
        {
            //Вертикальное меню
            string[] menu = { "Красный", 
                              "Зеленый", 
                              "Синий  ", 
                              "Выход  " };
            bool isRun = true;
            int current = 0, last = 0;
            while (isRun)
            {
                

                //вывод меню
                BaseColor();
                Console.Clear();
                Console.CursorVisible = false;
                for (int i = 0; i < menu.Length; i++)
                {
                    ShowMenuItem(i, menu[i]);
                }
                // выбор пункта меню
                bool isNoEnter = true;
                while (isNoEnter)
                {
                    BaseColor();
                    ShowMenuItem(last, menu[last]);
                    LightColor();
                    ShowMenuItem(current, menu[current]);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                        isNoEnter = false;
                    else
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            last = current;
                            current = (current == menu.Length - 1) ? 0 : current + 1;
                        }
                        else
                            if (keyInfo.Key == ConsoleKey.UpArrow)
                            {
                                last = current;
                                current = (current == 0) ? menu.Length - 1 : current - 1;
                            }
                }// конец тела цикла while (isNoEnter)
                
                // действие в соответствии с выбором пользователя
                switch (current)
                {
                    case 0:
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("Привет, Вася!");
                            Console.ReadKey();
                            break;
                        }
                    case 1:
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Clear();
                            Console.WriteLine("Привет, Петя!");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Привет, Миша!");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        { isRun = false; break; }
                }
                
            }// конец цикла while (isRun)
        }
    }
}
