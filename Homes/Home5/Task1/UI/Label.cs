using System;
using System.Collections.Generic;

namespace UI
{
    public class Label : BasicElement
    {
        int _offset;
        public string Text { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override void Draw(int x, int y)
        {
            if (Active)
                ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
            string[] str = FormStrings();
            for (int i = 0; i < str.Length; i++)
            {
                if (i > Height)
                    return;
                Console.SetCursorPosition(X + x, Y + y + i);
                Console.Write(str[i + _offset]);
            }
            if (Active)
                ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
        }

        string[] FormStrings()
        {
            List<string> result = new List<string>();
            string[] strings = Text.Split('\n');

            foreach (string str in strings)
                for (int i = 0; str.Length > i * Width; i++)
                    result.Add(
                        str.Substring(i * Width,
                            str.Length > (i + 1) * Width
                                ? Width
                                : str.Length - i * Width));

            return result.ToArray();
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(X + x, Y + y);
            Console.CursorVisible = false;
        }

        bool IncreaseOffset()
        {
            if (Height + _offset + 1 >= FormStrings().Length) return false;
            _offset++;
            return true;
        }

        bool DecreaseOffset()
        {
            if (_offset == 0) return false;
            _offset--;
            return true;
        }

        public override bool OnKeyPress(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    return IncreaseOffset();
                case ConsoleKey.UpArrow:
                    return DecreaseOffset();
            }
            return false;
        }
    }
}