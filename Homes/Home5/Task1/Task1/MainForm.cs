using System;
using UI;
using UI.Menu;

namespace Task1
{
    public class MainForm : Form
    {
        readonly SubMenu _file = new SubMenu("File");
        readonly Menu _menu = new Menu();

        readonly MenuItem _load = new MenuItem("Load");
        readonly MenuItem _save = new MenuItem("Save");
        readonly SubMenu _about = new SubMenu("About");

        readonly MenuItem _add = new MenuItem("Add record");
        readonly MenuItem _delete = new MenuItem("Delete record");
        readonly SubMenu _edit = new SubMenu("Edit");
        readonly MenuItem _exit = new MenuItem("Exit");

        public MainForm()
        {
            _file.AddItem(_load);
            _file.AddItem(_save);
            _file.AddItem(_exit);

            _edit.AddItem(_add);
            _edit.AddItem(_delete);

            _exit.MenuItemClick += MenuExit_click;
            _add.MenuItemClick += MenuAdd_click;
            _about.SubMenuClick += MenuAbout_click;

            _menu.AddItem(_file);
            _menu.AddItem(_edit);
            _menu.AddItem(_about);

            AddElement(_menu);
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