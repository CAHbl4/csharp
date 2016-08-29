using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu.Properties
{
    public class SubMenu
    {
        private readonly List<MenuItem> items;
        private MenuItem selected;
        
        public SubMenu(string text = "")
        {
            items = new List<MenuItem>();
            Text = text;
            selected = null;
        }

        public string Text { get; set; }

        public void AddItem(MenuItem item)
        {
            items.Add(item);
        }

        public void AddItem(string text)
        {
            AddItem(new MenuItem(text));
        }

        public void SelectNext()
        {
            if (items.LastOrDefault() != selected)
                selected = items[items.FindIndex(x => x == selected) + 1];
        }

        public void SelectPrev()
        {
            if (selected != null)
            {
                selected = items.FirstOrDefault() != selected
                    ? items[items.FindIndex(x => x == selected) - 1]
                    : null;    
            }
            
        }

        public void Draw(int spaceCount)
        {
            if (selected != null)
            {
                ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
                string space = new string(' ', spaceCount);
                foreach (var menuItem in items)
                {
                    Console.Write(space);
                    if (menuItem == selected)
                        ConsoleUtils.ConsoleSetColors(ConsoleColors.Active);
                    Console.WriteLine(" {0} ", menuItem);
                    if (menuItem == selected)
                        ConsoleUtils.ConsoleSetColors(ConsoleColors.Default);
                }
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}