namespace UI
{
    public enum DialogResult
    {
        OK,
        Cancel,
        None
    }

    public static class MessageBox
    {
        public static DialogResult Show(string text)
        {
            Form form = new Form {Title = "Message", HasBorder = true, Width = 40, Height = 10};

            Label label = new Label {Text = text, Right = 0, Top = 0, Width = 38, Height = 6, Enabled = false};
            Button buttonOK = new Button("OK") {Right = 18, Top = 7};

            DialogResult result = DialogResult.None;

            buttonOK.ButtonClick += (sender, args) =>
            {
                result = DialogResult.OK;
                form.Dispose();
            };

            form.AddElement(label);
            form.AddElement(buttonOK);

            form.Init();
            form.Execute();

            return result;
        }
    }
}