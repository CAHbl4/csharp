using System;

namespace UI
{
    public class Button : BasicElement
    {
        readonly Action _action;
        readonly string _text;

        public Button(string text, Action action)
        {
            _text = text;
            _action = action;
        }

        public override void Draw(int x, int y)
        {
            Console.SetCursorPosition(X + x, Y + y);
            ConsoleUtils.ConsoleSetColors(Active ? ConsoleColors.Active : ConsoleColors.Inverted);
            Console.Write($" {_text} ");
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(X + x, Y + y);
            Console.CursorVisible = false;
        }

        public override bool OnKeyPress(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.Enter:
                    _action?.Invoke();
                    return true;
            }
            return false;
        }
    }
}