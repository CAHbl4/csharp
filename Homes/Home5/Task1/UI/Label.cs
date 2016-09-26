using System;

namespace UI
{
    public class Label : BasicElement
    {
        public override bool UseArrows => false;
        public string Text { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override void Draw(int x, int y)
        {
            int i = 0;
            string[] strings = Text.Split('\n');
            foreach (string str in strings)
                for (int k = 0; str.Length > k * Width; k++, i++)
                {
                    Console.SetCursorPosition(X + x, Y + y + i);
                    Console.Write(str.Substring(
                        k * Width, str.Length > Width
                            ? Width
                            : str.Length));
                    if (Height - i == 0) return;
                }
        }

        public override void OnKeyPress(ConsoleKey key)
        {
        }
    }
}