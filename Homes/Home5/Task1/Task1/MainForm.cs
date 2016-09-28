using System;
using UI;
using UI.Menu;

namespace Task1
{
    public class MainForm : Form
    {
        public Menu Menu { get; } = new Menu();

        public MainForm()
        {
            SubMenu file = new SubMenu("File");

            MenuItem load = new MenuItem("Load");
            file.AddItem(load);

            MenuItem save = new MenuItem("Save");
            file.AddItem(save);

            MenuItem exit = new MenuItem("Exit");
            exit.MenuItemClick += MenuExit_click;
            file.AddItem(exit);

            Menu.AddItem(file);

            SubMenu edit = new SubMenu("Edit");

            MenuItem add = new MenuItem("Add record");
            add.MenuItemClick += MenuAdd_click;
            edit.AddItem(add);

            MenuItem delete = new MenuItem("Delete record");
            edit.AddItem(delete);

            Menu.AddItem(edit);

            SubMenu about = new SubMenu("About");
            about.SubMenuClick += MenuAbout_click;

            Menu.AddItem(about);

            AddElement(Menu);
        }

        void MenuExit_click(object sender, EventArgs e)
        {
            Dispose();
        }

        static void MenuAdd_click(object sender, EventArgs e)
        {
            Form form = new AddForm {Title = "Add", Width = 40, Height = 15, HasBorder = true};

            form.Init();
            form.Execute();
        }

        static void MenuAbout_click(object sender, EventArgs e)
        {
            Form form = new AboutForm {Title = "About", Width = 40, Height = 15, HasBorder = true};

            form.Init();
            form.Execute();
        }
    }
}