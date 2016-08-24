using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Properties;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            SubMenu file = new SubMenu("File");
            file.AddItem("New");
            file.AddItem("Save");
            file.AddItem("Exit");

            SubMenu edit = new SubMenu("Edit");
            edit.AddItem("Cut");
            edit.AddItem("Copy");
            edit.AddItem("Paste");

            menu.AddItem(file);
            menu.AddItem(edit);
            menu.AddItem("About");
            menu.Execute();
         }
    }
}
