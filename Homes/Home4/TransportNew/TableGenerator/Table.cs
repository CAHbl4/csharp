using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableGenerator
{
    /// <summary>
    ///     Класс для генерация таблиц
    /// </summary>
    public class Table
    {
        private readonly List<Column> columns = new List<Column>();

        public Table()
        {
        }

        public Table(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public int Width
        {
            get { return columns.Sum(x => x.Width) + columns.Count + 1; }
        }


        /// <summary>
        ///     Добавляет колонку в таблицу
        /// </summary>
        /// <param name="columnTitle">Заголовок колонки</param>
        /// <param name="columnWidth">Ширина колонки</param>
        /// <param name="align">Направление выравнивания</param>
        public void AddColumn(string columnTitle, int columnWidth, Align align = Align.Center)
        {
            columns.Add(new Column(columnTitle, columnWidth, align));
        }

        public int GetColumnsCount()
        {
            return columns.Count;
        }

        public void RemoveColumn(int index)
        {
            if ((index >= 0) && (index < columns.Count))
                columns.RemoveAt(index);
        }

        public void ClearColumns()
        {
            columns.Clear();
        }

        public Column GetColumn(int index)
        {
            if ((index >= 0) && (index < columns.Count))
                return columns[index];
            return null;
        }


        /// <summary>
        ///     Рисует шапку
        /// </summary>
        public void DrawHead()
        {
            var str = new List<StringBuilder>(5);
            for (int i = 0; i < str.Capacity; i++)
                str.Add(new StringBuilder(Width));

            //str[0] Верхняя граница                                       "╔════════════════════╗"
            //str[1] Заголовок таблицы                                     "║     Заголовок      ║"
            //str[2] Граница между заголовком таблицы и именами колонок    "╠═══╤══════╤═════════╣"
            //str[3] Имена колонок                                         "║ № │ Имя  │ Фамилия ║"
            //str[4] Граница между именами колонок и содержимым            "╠═══╪══════╪═════════╣"

            if (!string.IsNullOrEmpty(Title))
            {
                str[0].Append('╔');
                str[0].Append('═', Width - 2);
                str[0].Append('╗');

                str[1].Append('║');
                str[1].Append(Title.Length <= Width - 2
                    ? Title.Center(Width - 2)
                    : Title.Substring(0, Width - 2));
                str[1].Append("║");
            }

            str[2].Append(!string.IsNullOrEmpty(Title) ? '╠' : '╔');
            str[3].Append('║');
            str[4].Append('╠');
            foreach (Column c in columns)
            {
                str[2].Append('═', c.Width);
                str[2].Append('╤');
                str[3].Append(c.Title.Length <= c.Width
                    ? c.Title.Center(c.Width)
                    : c.Title.Substring(0, c.Width));
                str[3].Append('│');
                str[4].Append('═', c.Width);
                str[4].Append('╪');
            }
            str[2].Replace('╤', !string.IsNullOrEmpty(Title) ? '╣' : '╗', str[2].Length - 1, 1);
            str[3].Replace('│', '║', str[3].Length - 1, 1);
            str[4].Replace('╪', '╣', str[4].Length - 1, 1);

            foreach (StringBuilder s in str)
                if (s.ToString() != "")
                    Console.WriteLine(s);
        }

        /// <summary>
        ///     Выводит строку, принимает строковые аргументы для заполнения
        /// </summary>
        /// <param name="color">Цвет значений</param>
        /// <param name="values">Строки для вывода в таблице</param>
        public void DrawRow(ConsoleColor color, params string[] values)
        {
            StringBuilder str = new StringBuilder(Width);

            ConsoleColor current = Console.ForegroundColor;

            Console.ForegroundColor = current;
            Console.Write('║');
            Console.ForegroundColor = color;
            for (int i = 0; i < columns.Count; i++)
            {
                if (values.GetUpperBound(0) >= i)
                    if (values[i].Length >= columns[i].Width)
                    {
                        Console.Write(values[i].Substring(0, columns[i].Width));
                    }
                    else
                        switch (columns[i].Align)
                        {
                            case Align.Left:
                                Console.Write(values[i].PadRight(columns[i].Width));
                                break;
                            case Align.Center:
                                Console.Write(values[i].Center(columns[i].Width));
                                break;
                            case Align.Right:
                                Console.Write(values[i].PadLeft(columns[i].Width));
                                break;
                        }
                else
                    Console.Write(new string(' ', columns[i].Width));
                Console.ForegroundColor = current;
                Console.Write(i != columns.Count - 1 ? '│' : '║');
                Console.ForegroundColor = color;
            }

            Console.ForegroundColor = current;
            Console.WriteLine(str);
        }


        /// <summary>
        ///     Выводит строку, принимает строковые аргументы для заполнения
        /// </summary>
        /// <param name="values">Строки для вывода в таблице</param>
        public void DrawRow(params string[] values)
        {
           DrawRow(Console.ForegroundColor, values);
        }

        /// <summary>
        ///     Рисует подвал таблицы
        /// </summary>
        public void DrawFooter()
        {
            StringBuilder str = new StringBuilder(Width + 1);
            str.Append('╚');
            foreach (Column c in columns)
            {
                str.Append('═', c.Width);
                str.Append('╧');
            }
            str.Replace('╧', '╝', str.Length - 1, 1);
            Console.WriteLine(str);
        }
    }
}