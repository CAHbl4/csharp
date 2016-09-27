using System;

namespace UI
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
                case ConsoleColors.Inverted:
                    Console.BackgroundColor = Constants.InvertedBackground;
                    Console.ForegroundColor = Constants.InvertedText;
                    break;
                case ConsoleColors.Interactive:
                    Console.BackgroundColor = Constants.InteractiveBackground;
                    Console.ForegroundColor = Constants.InteractiveText;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colors), colors, null);
            }
        }

        public static void DrawBorder(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('╔');
            Console.Write(new string('═', width - 2));
            Console.Write('╗');
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write('║');
                Console.SetCursorPosition(x + width - 1, y + i);
                Console.Write('║');
            }
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write('╚');
            Console.Write(new string('═', width - 2));
            Console.Write('╝');
        }
    }
}