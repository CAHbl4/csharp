using System;
using UI;

namespace Task1
{
    public class AboutForm : Form
    {
        readonly Button _buttonOK = new Button("OK") {Right = 17, Top = 12};

        readonly Label _text = new Label
        {
            Right = 0,
            Top = 0,
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

        public AboutForm()
        {
            _buttonOK.ButtonClick += _buttonOKClick;
            AddElement(_text);
            AddElement(_buttonOK);
        }

        void _buttonOKClick(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}