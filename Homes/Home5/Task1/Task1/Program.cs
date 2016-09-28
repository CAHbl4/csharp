using UI;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new MainForm();

            form.Init();
            form.Execute();
        }
    }
}