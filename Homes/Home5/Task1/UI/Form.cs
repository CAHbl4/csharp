using System;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public class Form: IContainer
    {
        readonly List<IElement> _elements = new List<IElement>();
        int _active;
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
            if (element == null) return;
            _elements.Add(element);
            element.Parrent = this;
        }

        public void RemoveElement(IElement element)
        {
            if (element == null) return;
            foreach (IElement el in _elements)
            {
                if (element == el)
                    _elements.Remove(element);
            }
        }

        public void Init()
        {
            if (_elements.Count > 0)
                _active = _elements.FindIndex(x => x.Enabled);
            _elements[_active].Active = true;
            Console.CursorVisible = false;
            Console.ForegroundColor = Constants.DefaultText;
            Console.BackgroundColor = Constants.DefaultBackground;
        }

        void Draw()
        {
            int x = (Console.WindowWidth - Width) / 2;
            int y = (Console.WindowHeight - Height) / 2;
            int width = Width;
            int height = Height;
            Console.Clear();
            if (HasBorder)
            {
                ConsoleUtils.DrawBorder(x, y, Width, Height);
                if (Title != null)
                {
                    Console.SetCursorPosition(x + (Width - Title.Length) / 2 - 1, y);
                    Console.Write($" {Title} ");
                }
                x++;
                y++;
                width -= 2;
                height -= 2;
            }
            else
            {
                if (Title != null) Console.Title = Title;
            }
            foreach (IElement element in _elements)
                if (element.Visible)
                    element.Draw(x, y, width, height);
            _elements[_active].SetCursor(x, y);
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
                    return;

                Draw();

                ConsoleKeyInfo cki = Console.ReadKey(false);

                if ((cki.Modifiers == ConsoleModifiers.Alt) && (cki.Key == ConsoleKey.X))
                {
                    Dispose();
                    continue;
                }

                if (_elements[_active].OnKeyPress(cki)) continue;

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                        Select(SelectDirection.Prev);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        Select(SelectDirection.Next);
                        break;
                    case ConsoleKey.Tab:
                        Select(SelectDirection.Next, true);
                        break;
                }
            }
        }

        public void Select(SelectDirection direction, bool cyclic = false)
        {
            if (cyclic)
            {
                if ((direction == SelectDirection.Next)
                    && (_elements[_active] == _elements.Last(x => x.Enabled)))
                    Select(_elements.FindIndex(x => x.Enabled));
                else if ((direction == SelectDirection.Prev)
                         && (_elements[_active] == _elements.First(x => x.Enabled)))
                    Select(_elements.FindLastIndex(x => x.Enabled));
                else Select(direction);
            }
            else
            {
                if ((direction == SelectDirection.Next)
                    && (_elements[_active] == _elements.Last(x => x.Enabled)))
                    return;
                if ((direction == SelectDirection.Prev)
                    && (_elements[_active] == _elements.First(x => x.Enabled)))
                    return;
                Select(direction == SelectDirection.Next
                    ? _elements.FindIndex(_active + 1, x => x.Enabled)
                    : _elements.FindLastIndex(_active - 1, _active, x => x.Enabled));
            }
        }

        public void Select(int index)
        {
            if (index < 0) return;
            _elements[_active].Active = false;
            _active = index;
            _elements[_active].Active = true;
        }

        public ICollection<IElement> Container => _elements.ToArray();
    }
}