using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.Menu
{
    public class SubMenu
    {
        readonly List<MenuItem> _items = new List<MenuItem>();
        MenuItem _selected;

        public void Deselect()
        {
            _selected = null;
        }

        public SubMenu(string text = "")
        {
            Text = text;
        }

        public bool HaveSelected => _selected != null;
        public int Count => _items.Count;
        public string Text { get; set; }

        public int Width => _items.Max(x => x.Text.Length);

        public event EventHandler<EventArgs> SubMenuClick;

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
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
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Inverted);
            int i = 0;
            foreach (MenuItem menuItem in _items)
            {
                Console.SetCursorPosition(x, y + i++);
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.ActiveInverted);
                Console.Write($" {menuItem.Text.PadRight(Width)} ");
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Inverted);
            }
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
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
                SubMenuClick?.Invoke(this, EventArgs.Empty);
            else
                _selected.Execute();
        }
    }
}