using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Lesson1_console
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Window mainWindow = new Window {Title = "WPF!"};

            Button btn1 = new Button {Content = "Click me", Height = 120, Width = 300};
            btn1.Click += (sender, eventArgs) => { MessageBox.Show("Hi!"); };

            mainWindow.Content = btn1;

            new Application().Run(mainWindow);
        }
    }
}