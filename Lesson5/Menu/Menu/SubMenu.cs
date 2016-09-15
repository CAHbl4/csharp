using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    public class SubMenu
    {
        private readonly List<MenuItem> _items;
        private MenuItem _selected;

        public SubMenu(string text = "")
        {
            _items = new List<MenuItem>();
            Text = text;
            _selected = null;
        }

        public string Text { get; set; }
        public event EventHandler<EventArgs> Executed;

        private void OnExecute(EventArgs e)
        {
            var handler = Executed;
            handler?.Invoke(this, e);
        }

        public void Execute()
        {
            if (_selected != null)
                _selected.Execute();
            else
                OnExecute(new EventArgs());
        }

        public MenuItem GetItem(string name)
        {
            return _items.First(x => x.Text == name);
        }

        public void AddItem(string text)
        {
            if (_items.Count == 0) _items.Add(new MenuItem(text));
            else if (_items.Any(x => x.Text != text))
                _items.Add(new MenuItem(text));
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

        public void ResetSelected()
        {
            _selected = null;
        }

        public void Draw(int spaceCount)
        {
            if (_selected == null) return;
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            string space = new string(' ', spaceCount);
            foreach (MenuItem menuItem in _items)
            {
                Console.Write(space);
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                Console.WriteLine($" {menuItem} ");
                if (menuItem == _selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}