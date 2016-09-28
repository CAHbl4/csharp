using System;

namespace UI.Menu
{
    public class MenuItem
    {
        public event EventHandler<EventArgs> MenuItemClick;

        public MenuItem(string text = "")
        {
            Text = text;
        }

        public string Text { get; set; }

        public void Execute()
        {
            MenuItemClick?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}