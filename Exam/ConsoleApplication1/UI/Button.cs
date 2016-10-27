using System;

namespace UI
{
    public class Button : BasicElement
    {
        readonly string _text;

        public Button(string text)
        {
            _text = text;
        }

        public event EventHandler<EventArgs> ButtonClick;

        public override void Draw(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(Right + x, Top + y);
            ConsoleUtils.ConsoleSetColors(Active ? ConsoleColors.ActiveInverted : ConsoleColors.Inverted);
            Console.Write($" {_text} ");
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(Right + x, Top + y);
            Console.CursorVisible = false;
        }

        public override bool OnKeyPress(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.Enter:
                    ButtonClick?.Invoke(this, EventArgs.Empty);
                    return true;
            }
            return false;
        }
    }
}