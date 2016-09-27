using System;

namespace UI
{
    public interface IElement
    {
        int X { get; set; }
        int Y { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        bool Active { get; set; }
        void Draw(int x, int y);
        bool OnKeyPress(ConsoleKeyInfo cki);
        void SetCursor(int x, int y);
    }
}