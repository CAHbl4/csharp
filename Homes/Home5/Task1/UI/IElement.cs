using System;

namespace UI
{
    public interface IElement
    {
        bool UseArrows { get; }
        int X { get; set; }
        int Y { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        bool Active { get; set; }
        void Draw(int x, int y);
        void OnKeyPress(ConsoleKey key);
    }
}