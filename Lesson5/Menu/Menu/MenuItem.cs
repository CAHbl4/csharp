using System;

namespace Menu
{
    public class MenuItem
    {

        public event EventHandler<EventArgs> Executed;

        private void OnExecute(EventArgs e)
        {
            var handler = Executed;
            handler?.Invoke(this, e);
        }

        public void Execute()
        {
            OnExecute(new EventArgs());
        }

        public MenuItem(string text = "")
        {
            Text = text;
        }

        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}