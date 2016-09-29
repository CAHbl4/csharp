using UI;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new MainForm() {Title = "Demo Forms App", HasBorder = false};

            form.Init();
            form.Execute();
        }
    }
}