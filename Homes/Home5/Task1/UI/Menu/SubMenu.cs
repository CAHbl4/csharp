using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Menu
{
    public class SubMenu
    {
        readonly Action _action;
        readonly List<MenuItem> _items;
        MenuItem _selected;

        public SubMenu(string text = "", Action action = null)
        {
            Text = text;
            _items = new List<MenuItem>();
            _selected = null;
            _action += action;
        }

        public bool HaveSelected => _selected != null;
        public int Count => _items.Count;
        public string Text { get; set; }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public void AddItem(string text, Action action = null)
        {
            AddItem(new MenuItem(text, action));
        }

        public void SelectNext()
        {
            if (_items.LastOrDefault() != _selected)
                _selected = _items[_items.FindIndex(x => x == _selected) + 1];
        }

        public void SelectPrev()
        {
            if (_selected != null)
                _selected = _items.FirstOrDefault() != _selected
                    ? _items[_items.FindIndex(x => x == _selected) - 1]
                    : null;
        }

        public void Draw(int x, int y)
        {
            if (_selected == null) return;
            int i = 0;
            foreach (MenuItem menuItem in _items)
            {
                Console.SetCursorPosition(x, y + i++);
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                Console.Write($" {menuItem} ");
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            }
        }

        public override string ToString()
        {
            return Text;
        }

        public void Reset()
        {
            _selected = null;
        }

        public void Execute()
        {
            if (_selected == null)
                _action?.Invoke();
            else
                _selected.Execute();
        }
    }
}