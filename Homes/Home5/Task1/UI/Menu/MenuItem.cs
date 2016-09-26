using System;

namespace UI.Menu
{
    public class MenuItem
    {
        readonly Action _action;

        public MenuItem(string text = "", Action action = null)
        {
            Text = text;
            _action += action;
        }

        public string Text { get; set; }

        public void Execute()
        {
            _action?.Invoke();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}