namespace Menu
{
    public class MenuItem
    {
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