using System;

namespace UI
{
    public interface IElement
    {
        int Top { get; set; }
        int Right { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        bool Active { get; set; }
        void Draw(int x, int y, int width, int height);
        bool OnKeyPress(ConsoleKeyInfo cki);
        void SetCursor(int x, int y);

        IContainer Parrent { get; set; }
    }
}