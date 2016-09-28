using System;
using UI;

namespace Task1
{
    public class AddForm : Form
    {
        public AddForm()
        {
            ButtonOK.ButtonClick += ButtonOK_click;

            AddElement(Text1);
            AddElement(Edit1);
            AddElement(Text2);
            AddElement(Edit2);
            AddElement(ButtonOK);
        }

        public Button ButtonOK { get; } = new Button("OK") {X = 18, Y = 13};
        public Edit Edit1 { get; } = new Edit {X = 10, Y = 1, Enabled = true, Width = 20};
        public Edit Edit2 { get; } = new Edit {X = 10, Y = 2, Enabled = true, Width = 20};

        public Label Text1 { get; } = new Label {X = 1, Y = 1, Enabled = false, Height = 1, Width = 8, Text = "Name"};

        public Label Text2 { get; } = new Label {X = 1, Y = 2, Enabled = false, Height = 1, Width = 8, Text = "Surname"}
            ;

        void ButtonOK_click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}