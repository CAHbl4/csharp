using System;
using BL;
using UI;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new MainForm() { Title = "Demo Forms App", HasBorder = false };

            form.Init();
            form.Execute();
        }
    }
}