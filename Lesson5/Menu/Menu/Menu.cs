using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    public class Menu
    {
        private readonly List<SubMenu> _items;
        private SubMenu _selected;

        public Menu()
        {
            _items = new List<SubMenu>();
        }

        public void AddItem(SubMenu item)
        {
            _items.Add(item);
            if (_items.Count == 1)
                _selected = _items[0];
        }

        public void AddItem(string text)
        {
            AddItem(new SubMenu(text));
        }

        public void SelectNext()
        {
            if (_items.LastOrDefault() == _selected) return;
            _selected.ResetSelected();
            _selected = _items[_items.FindIndex(x => x == _selected) + 1];
        }

        public void SelectPrev()
        {
            if (_items.FirstOrDefault() == _selected) return;
            _selected.ResetSelected();
            _selected = _items[_items.FindIndex(x => x == _selected) - 1];
        }

        private void Draw()
        {
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            Console.Clear();
            foreach (SubMenu menuItem in _items)
            {
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                Console.Write($" {menuItem} ");
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            }
            int subSpace = _items.TakeWhile(x => x != _selected).Sum(x => x.Text.Length + 2);
            Console.WriteLine();
            _selected.Draw(subSpace);
        }

        public void Execute()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo cki;
            do
            {
                Draw();
                cki = Console.ReadKey(false);
                switch (cki.Key)
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
                        _selected.Execute();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}