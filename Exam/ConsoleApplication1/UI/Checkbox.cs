using System;

namespace UI
{
    public class CheckBox: BasicElement
    {
        public bool Checked { get; set; }
        public string Text { get; set; }
        public event EventHandler<EventArgs> CheckedChanged;

        public override void Draw(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(Right + x, Top + y);
            ConsoleUtils.ConsoleSetColors(Active ? ConsoleColors.Active : ConsoleColors.Default);
            Console.Write($"[{(Checked ? "x" : " ")}] {Text}");
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
        }

        public void Switch()
        {
            Checked = !Checked;
        }
        public override bool OnKeyPress(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    Switch();
                    CheckedChanged?.Invoke(this, EventArgs.Empty);
                    return true;
            }
            return false;
        }

        public override void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(Right + x + 1, Top + y);
            Console.CursorVisible = true;
        }
    }
}