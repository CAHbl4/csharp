using System;

namespace UI
{
    public abstract class BasicElement : IElement
    {
        protected BasicElement()
        {
            Enabled = true;
            Visible = true;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public abstract void Draw(int x, int y);
        public abstract bool OnKeyPress(ConsoleKeyInfo cki);
        public abstract void SetCursor(int x, int y);
    }
}