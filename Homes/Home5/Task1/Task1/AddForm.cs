using System;
using UI;

namespace Task1
{
    public class AddForm : Form
    {
        readonly Edit _edit1 = new Edit {Right = 10, Top = 1, Enabled = true, Width = 20, MaxLength = 100};
        readonly Edit _edit2 = new Edit {Right = 10, Top = 2, Enabled = true, Width = 20, MaxLength = 10 };

        readonly Label _text1 = new Label {Right = 1, Top = 1, Enabled = false, Height = 1, Width = 8, Text = "Name"};

        readonly Label _text2 = new Label {Right = 1, Top = 2, Enabled = false, Height = 1, Width = 8, Text = "Surname"}
            ;

        readonly Button _buttonOK = new Button("OK") {Right = 12, Top = 12};
        readonly Button _buttonCancel = new Button("Cancel") {Right = 17, Top = 12};

        public AddForm()
        {
            _buttonOK.ButtonClick += ButtonOK_click;
            _buttonCancel.ButtonClick += ButtonCancel_click;

            AddElement(_text1);
            AddElement(_edit1);
            AddElement(_text2);
            AddElement(_edit2);
            AddElement(_buttonOK);
            AddElement(_buttonCancel);
        }

        void ButtonOK_click(object sender, EventArgs e)
        {
            MessageBox.Show("Sample Text");
        }

        void ButtonCancel_click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}