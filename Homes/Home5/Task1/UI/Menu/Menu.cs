using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Menu
{
    public class Menu : BasicElement
    {
        readonly List<SubMenu> _items;
        SubMenu _selected;

        public Menu()
        {
            _items = new List<SubMenu>();
        }

        public override bool UseArrows => true;

        public override void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            foreach (SubMenu menuItem in _items)
            {
                if (menuItem == _selected)
                {
                    x = Console.CursorLeft;
                    y = Console.CursorTop + 1;
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                }
                Console.Write($" {menuItem} ");
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            }
            _selected?.Draw(x, y);
        }

        public override void OnKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    SelectPrev();
                    break;
                case ConsoleKey.RightArrow:
                    SelectNext();
                    break;
                case ConsoleKey.UpArrow:
                    _selected.SelectPrev();
                    break;
                case ConsoleKey.DownArrow:
                    _selected.SelectNext();
                    break;
                case ConsoleKey.Enter:
                    if ((_selected.Count > 0) && !_selected.HaveSelected)
                        _selected.SelectNext();
                    else
                        _selected.Execute();
                    break;
            }
        }

        public void AddItem(SubMenu item)
        {
            _items.Add(item);
            if (_items.Count == 1)
                _selected = _items[0];
        }

        public void AddItem(string text, Action action = null)
        {
            AddItem(new SubMenu(text, action));
        }

        public void SelectNext()
        {
            if (_items.LastOrDefault() == _selected) return;
            _selected.Reset();
            _selected = _items[_items.FindIndex(x => x == _selected) + 1];
        }

        public void SelectPrev()
        {
            if (_items.FirstOrDefault() == _selected) return;
            _selected.Reset();
            _selected = _items[_items.FindIndex(x => x == _selected) - 1];
        }
    }
}