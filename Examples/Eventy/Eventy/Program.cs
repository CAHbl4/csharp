using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventy
{

    class Program
    {
        static void OnEsc(object sender,ConsoleKey k)
        {
            if (k == ConsoleKey.Escape)
                ((ConsoleForm)sender).IsEnd = true;
            
        }
        static void OnArrowDown(object sender, ConsoleKey k)
        {
            if (k == ConsoleKey.DownArrow && ((ConsoleForm)sender).Color !=(ConsoleColor) 15)
                ((ConsoleForm)sender).Color+=1;

        }
        static void OnArrowUp(object sender, ConsoleKey k)
        {
            if (k == ConsoleKey.UpArrow && ((ConsoleForm)sender).Color!=0)
                ((ConsoleForm)sender).Color -= 1;

        }
        static void Main(string[] args)
        {
            ConsoleForm form = new ConsoleForm();
            form.PressKey += OnEsc;
            form.PressKey += OnArrowUp;
            form.PressKey += OnArrowDown;
            form.Run();
        }
    }
}
