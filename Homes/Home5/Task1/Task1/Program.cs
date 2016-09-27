using UI;
using UI.Menu;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            Menu menu = new Menu();

            SubMenu file = new SubMenu("File");
            file.AddItem("Load");
            file.AddItem("Save");
            file.AddItem("Exit", form.Dispose);

            SubMenu edit = new SubMenu("Edit");
            edit.AddItem("Add record", Add);

            menu.AddItem(file);
            menu.AddItem(edit);
            menu.AddItem("About", About);

            form.AddElement(menu);

            form.Init();
            form.Execute();
        }

        static void Add()
        {
            Form form = new Form {Title = "Add", Width = 40, Height = 15, HasBorder = true};

            Button buttonOK = new Button("OK", form.Dispose) {X = 18, Y = 13};

            Label text1 = new Label {X = 1, Y = 1, Enabled = false, Height = 1, Width = 8, Text = "Name"};
            Edit edit1 = new Edit {X = 10, Y = 1, Enabled = true, Width = 20};

            Label text2 = new Label {X = 1, Y = 2, Enabled = false, Height = 1, Width = 8, Text = "Surname"};
            Edit edit2 = new Edit {X = 10, Y = 2, Enabled = true, Width = 20};

            form.AddElement(text1);
            form.AddElement(edit1);
            form.AddElement(text2);
            form.AddElement(edit2);
            form.AddElement(buttonOK);

            form.Init();
            form.Execute();
        }

        static void About()
        {
            Form form = new Form {Title = "About", Width = 40, Height = 15, HasBorder = true};

            Button buttonOK = new Button("OK", form.Dispose) {X = 18, Y = 13};
            Label text = new Label
            {
                X = 1,
                Y = 1,
                Enabled = false,
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

            form.AddElement(text);
            form.AddElement(buttonOK);

            form.Init();
            form.Execute();
        }
    }
}