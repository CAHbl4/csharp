using System;
using System.Text;

namespace UI
{
    public class Edit : BasicElement
    {
        readonly StringBuilder _value = new StringBuilder();
        int _cursorPosition;

        public string Value
        {
            get { return _value.ToString(); }
            set
            {
                _value.Clear();
                _value.Append(value);
            }
        }

        public int Width { get; set; }

        public override void Draw(int x, int y)
        {
            Console.SetCursorPosition(X + x, Y + y);
            ConsoleUtils.ConsoleSetColors(Active ? ConsoleColors.ActiveInverted : ConsoleColors.Interactive);
            Console.Write(_value.ToString().PadRight(Width));
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(X + x + _cursorPosition, Y + y);
            Console.CursorVisible = true;
        }

        public override bool OnKeyPress(ConsoleKeyInfo cki)
        {
            if ((cki.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                return false;
            if ((cki.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
                return false;

            switch (cki.Key)
            {
                case ConsoleKey.RightArrow:
                    if ((_cursorPosition < Width) && (_cursorPosition < _value.Length))
                        _cursorPosition++;
                    return true;
                case ConsoleKey.LeftArrow:
                    if (_cursorPosition > 0)
                        _cursorPosition--;
                    return true;
                case ConsoleKey.Backspace:
                    if (_cursorPosition > 0)
                        _value.Remove(_cursorPosition-- - 1, 1);
                    return true;
                case ConsoleKey.Delete:
                    if (_cursorPosition < _value.Length)
                        _value.Remove(_cursorPosition, 1);
                    return true;
                case ConsoleKey.Enter:
                case ConsoleKey.Tab:
                    return false;
            }

            if (cki.KeyChar == '\u0000') return false;
            if (_value.Length < Width)
                _value.Insert(_cursorPosition++, cki.KeyChar);
            return true;
        }
    }
}