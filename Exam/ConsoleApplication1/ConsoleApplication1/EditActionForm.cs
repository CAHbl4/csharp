using System;
using UI;
using BL;

namespace ConsoleApplication1
{
    public class EditActionForm : Form
    {
        readonly Label labelName = new Label { Right = 1, Top = 1, Enabled = false, Height = 1, Width = 18, Text = "Name" };
        readonly Edit editName = new Edit { Right = 20, Top = 1, Enabled = true, Width = 27, MaxLength = 40 };

        readonly Label labelDirector = new Label { Right = 1, Top = 2, Enabled = false, Height = 1, Width = 18, Text = "Director" }
            ;
        readonly Edit editDirector = new Edit { Right = 20, Top = 2, Enabled = true, Width = 27, MaxLength = 40 };

        readonly Label labelActionDirector = new Label { Right = 1, Top = 3, Enabled = false, Height = 1, Width = 18, Text = "Action Director" }
            ;
        readonly Edit editActionDirector = new Edit { Right = 20, Top = 3, Enabled = true, Width = 27, MaxLength = 40 };
        
        readonly Button _buttonOK = new Button("OK") { Right = 20, Top = 12 };
        readonly Button _buttonCancel = new Button("Cancel") { Right = 25, Top = 12 };

        public EditActionForm()
        {
            _buttonOK.ButtonClick += ButtonOK_click;
            _buttonCancel.ButtonClick += ButtonCancel_click;

            AddElement(labelName);
            AddElement(editName);
            AddElement(labelDirector);
            AddElement(editDirector);
            AddElement(labelActionDirector);
            AddElement(editActionDirector);

            AddElement(_buttonOK);
            AddElement(_buttonCancel);
        }

        public event EventHandler<AbstractMovie> MovieAdd;

        void ButtonOK_click(object sender, EventArgs e)
        {
            BL.Action movie = new BL.Action(editName.Value, editDirector.Value, 12, 13, editActionDirector.Value);
            MovieAdd?.Invoke(this, movie);
            Dispose();
        }

        void ButtonCancel_click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}