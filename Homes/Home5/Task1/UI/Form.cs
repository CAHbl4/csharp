using System;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public class Form
    {
        readonly List<IElement> _elements = new List<IElement>();
        IElement _active;
        bool _dispose;

        public Form()
        {
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            HasBorder = false;
            _dispose = false;
        }

        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool HasBorder { get; set; }

        public void AddElement(IElement element)
        {
            _elements.Add(element);
        }

        public void Init()
        {
            if (_elements.Count > 0)
                _active = _elements.First(x => x.Enabled);
            _active.Active = true;
            Console.CursorVisible = false;
            Console.ForegroundColor = Constants.DefaultText;
            Console.BackgroundColor = Constants.DefaultBackground;
        }

        void Draw()
        {
            int x = (Console.WindowWidth - Width) / 2;
            int y = (Console.WindowHeight - Height) / 2;
            Console.Clear();
            if (HasBorder)
            {
                --x;
                --y;
                ConsoleUtils.DrawBorder(x, y, Width, Height);
                Console.SetCursorPosition(x + (Width - Title.Length) / 2 - 1, y);
                Console.Write($" {Title} ");
            }
            foreach (IElement element in _elements)
                if (element.Visible)
                    element.Draw(x, y);
            Console.SetCursorPosition(0, 0);
        }

        public void Dispose()
        {
            _dispose = true;
        }

        public void Execute()
        {
            while (true)
            {
                if (_dispose)
                    break;
                Draw();
                ConsoleKeyInfo cki = Console.ReadKey(false);
                if ((cki.Modifiers == ConsoleModifiers.Alt) && (cki.Key == ConsoleKey.X))
                    break;
                if (!_active.UseArrows)
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.LeftArrow:
                            Select(SelectDirection.Prev);
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.RightArrow:
                            Select(SelectDirection.Next);
                            break;
                        default:
                            _active.OnKeyPress(cki.Key);
                            break;
                    }
                else
                    _active.OnKeyPress(cki.Key);
            }
        }

        public void Select(SelectDirection direction)
        {
            if ((direction == SelectDirection.Next) && (_elements.Last(x => x.Enabled) == _active)) return;
            if ((direction == SelectDirection.Prev) && (_elements.First(x => x.Enabled) == _active)) return;
            _active.Active = false;
            _active = direction == SelectDirection.Next
                ? _elements[_elements.FindIndex(x => x == _active) + 1]
                : _elements[_elements.FindIndex(x => x == _active) - 1];
            _active.Active = true;
        }
    }
}