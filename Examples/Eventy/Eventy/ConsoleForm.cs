using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventy
{   public delegate void MyEventHandler(object sender,ConsoleKey key);
    class ConsoleForm
    {
        MyEventHandler[] handlers=new MyEventHandler[3];

        public ConsoleColor Color {get;set;}
        bool isEnd=false;
        public ConsoleForm()
        {
            Color = ConsoleColor.Blue;
        }
         public bool IsEnd
         {
             get
         {
             return isEnd;
         }
             set
             {
                   isEnd=value; 
             }
         }
        public event MyEventHandler PressKey
        {
            add
            {
                for (int i = 0; i < handlers.Length; i++)
                {
                    if (handlers[i] == null)
                    {
                        handlers[i] = value;
                        break;
                    }
                }
            }
            remove
            {
                for (int i = 0; i < handlers.Length; i++)
                    if (handlers[i] == value)
                        handlers[i] = null;  
            }
        }
            public void Run()
            {
                while(!IsEnd)
                {
                                  Console.BackgroundColor=Color;
                    Console.Clear();
                    Console.WriteLine("Работает ОМОН");
                    ConsoleKey key= Console.ReadKey().Key;
                 for(int i=0;i<handlers.Length;i++)
                     handlers[i](this,key);   
                }
            }
        }
    }

