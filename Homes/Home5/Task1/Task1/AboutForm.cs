using System;
using UI;

namespace Task1
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            ButtonOK.ButtonClick += _buttonOKClick;
            AddElement(Text);
            AddElement(ButtonOK);
        }

        public Button ButtonOK { get; } = new Button("OK") {X = 18, Y = 13};

        public Label Text { get; } = new Label
        {
            X = 1,
            Y = 1,
            Enabled = true,
            Height = 10,
            Width = 38,
            Text = "This is sample about text\n" +
                   "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod" +
                   " tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam," +
                   " quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
                   " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore" +
                   " eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                   " sunt in culpa qui officia deserunt mollit anim id est laborum."
        };

        void _buttonOKClick(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}