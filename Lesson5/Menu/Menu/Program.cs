using System;
using System.Runtime.Remoting.Messaging;

namespace Menu
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu menu = new Menu();

            SubMenu file = new SubMenu("File");
            file.AddItem("New");
            file.AddItem("Save");
            file.AddItem("Exit");

            file.GetItem("Exit").Executed += (obj, e) => Environment.Exit(0);

            SubMenu edit = new SubMenu("Edit");
            edit.AddItem("Cut");
            edit.AddItem("Copy");
            edit.AddItem("Paste");

            SubMenu about = new SubMenu("About");
            about.Executed += AboutHandler;

            menu.AddItem(file);
            menu.AddItem(edit);
            menu.AddItem(about);
            menu.Execute();
        }

        public static void AboutHandler(object sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Simple Menu Program");
            Console.ReadKey();
        }

    }
}