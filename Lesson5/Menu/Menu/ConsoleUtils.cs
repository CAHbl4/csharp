using System;
using Menu.Properties;

namespace Menu
{
    public static class ConsoleUtils
    {
        public static void ConsoleSetColors(ConsoleColors colors)
        {
            switch (colors)
            {
                case ConsoleColors.Active:
                    Console.BackgroundColor = Constants.ActiveBackground;
                    Console.ForegroundColor = Constants.ActiveText;
                    break;
                case ConsoleColors.Default:
                    Console.BackgroundColor = Constants.DefaultBackground;
                    Console.ForegroundColor = Constants.DefaultText;
                    break;
            }
        }
    }
}