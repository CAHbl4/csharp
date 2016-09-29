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

        public int Right { get; set; }
        public int Top { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public abstract void Draw(int x, int y, int width, int height);
        public abstract bool OnKeyPress(ConsoleKeyInfo cki);
        public abstract void SetCursor(int x, int y);
    }
}