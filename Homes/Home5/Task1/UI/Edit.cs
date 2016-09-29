using System;
using System.Text;

namespace UI
{
    public class Edit : BasicElement
    {
        readonly StringBuilder _value = new StringBuilder();
        int _cursorPosition;
        int _offset;

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
        public int MaxLength { get; set; }

        public override void Draw(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(Right + x, Top + y);
            ConsoleUtils.ConsoleSetColors(Active ? ConsoleColors.ActiveInverted : ConsoleColors.Interactive);
            Console.Write(
                _value.ToString(
                    _offset, _value.Length - _offset < Width
                        ? _value.Length - _offset
                        : Width).PadRight(Width));
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(Right + x + _cursorPosition, Top + y);
            Console.CursorVisible = true;
        }

        void Insert(char c)
        {
            if (_value.Length >= MaxLength) return;
            _value.Insert(_cursorPosition + _offset, c);
            CursorRight();
        }

        void CursorLeft()
        {
            if ((_cursorPosition == 0) && (_offset > 0))
                _offset--;
            else if (_cursorPosition > 0)
                _cursorPosition--;
        }

        void CursorRight()
        {
            if ((_cursorPosition + 1 == Width) && (_offset + Width - 1 < _value.Length))
                _offset++;
            else if ((_cursorPosition + 1 != Width) && (_cursorPosition + _offset < _value.Length))
                _cursorPosition++;
        }

        void Backspace()
        {
            if (_offset + _cursorPosition == 0) return;
            _value.Remove(_offset + _cursorPosition - 1, 1);
            CursorLeft();
        }

        void Delete()
        {
            if (_offset + _cursorPosition == _value.Length) return;
            _value.Remove(_offset + _cursorPosition, 1);
        }

        void Home()
        {
            _cursorPosition = 0;
            _offset = 0;
        }

        void End()
        {
            if (_value.Length > Width)
            {
                _cursorPosition = Width - 1;
                _offset = _value.Length - Width + 1;
            }
            else
            {
                _cursorPosition = _value.Length;
            }
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
                    CursorRight();
                    return true;
                case ConsoleKey.LeftArrow:
                    CursorLeft();
                    return true;
                case ConsoleKey.Home:
                    Home();
                    break;
                case ConsoleKey.End:
                    End();
                    break;
                case ConsoleKey.Backspace:
                    Backspace();
                    return true;
                case ConsoleKey.Delete:
                    Delete();
                    return true;

                case ConsoleKey.Enter:
                case ConsoleKey.Tab:
                case ConsoleKey.Escape:
                    return false;
            }

            if (cki.KeyChar == '\u0000') return false;
            Insert(cki.KeyChar);
            return true;
        }
    }
}