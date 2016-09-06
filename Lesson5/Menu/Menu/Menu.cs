using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using Menu.Properties;

namespace Menu
{
    public class Menu
    {
        private readonly List<SubMenu> items;
        private SubMenu selected;

        public Menu()
        {
            items = new List<SubMenu>();
        }

        public void AddItem(SubMenu item)
        {
            items.Add(item);
            if (items.Count == 1)
                selected = items[0];
        }

        public void AddItem(string text)
        {
            AddItem(new SubMenu(text));
        }

        public void SelectNext()
        {
            if (items.LastOrDefault() != selected)
                selected = items[items.FindIndex(x => x == selected) + 1];
        }

        public void SelectPrev()
        {
            if (items.FirstOrDefault() != selected)
                selected = items[items.FindIndex(x => x == selected) - 1];
        }

        

        private void Draw()
        {
            ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
            Console.Clear();
            foreach (var menuItem in items)
            {
                if (menuItem == selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                Console.Write(" {0} ", menuItem);
                if (menuItem == selected)
                    ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);

            }
            int subSpace = items.TakeWhile(x => x != selected).Sum(x => x.Text.Length + 2);
            Console.WriteLine();
            selected.Draw(subSpace);

        }

        public void Execute()
        {
            ConsoleKeyInfo cki;
            do
            {
                Draw();
                cki = Console.ReadKey(false);
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        SelectPrev();
                        break;
                    case ConsoleKey.RightArrow:
                        SelectNext();
                        break;
                    case ConsoleKey.UpArrow:
                        selected.SelectPrev();
                        break;
                    case ConsoleKey.DownArrow:
                        selected.SelectNext();
                        break;
                        
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}