using System.IO;
using System;

namespace MassivyObjectov
{
    class Table
    {
        string title;//заголовок таблицы
        int colCount;//количество столбцов таблицы
        string[] heads;//заголовки столбцов
        int[] size;  //ширина столбцов

        public Table( string ttl, int cnt, int[] sz, params string[] h)
        { title = ttl; colCount = cnt; size = sz; heads = h;  }

        private string Line(int n)
        { string s = ""; for (int i = 0; i < n; i++) s = s + "═"; return s; }

        private string FormatString()
        {
            string s = "║"; for (int j = 0; j < colCount; j++) { s = s + "  {" + j + ",-" + (size[j] - 2) + "}║"; };
            return s;
        }

        public void TableHead()
        {
            Console.WriteLine(title);
            Console.Write("╔"); Console.Write(Line(size[0]));
            for (int j = 0; j < colCount - 1; j++)
            {
                Console.Write("╦"); Console.Write(Line(size[j + 1]));

            }
            Console.WriteLine("╗");

            Console.WriteLine(FormatString(), heads);
            Console.Write("╠"); Console.Write(Line(size[0]));
            for (int j = 0; j < colCount - 1; j++)
            {
                Console.Write("╬"); Console.Write(Line(size[j + 1]));
            }
            Console.WriteLine("╣"); ;

        }
        public void TableLine(params string[] data)
        {

            Console.WriteLine(FormatString(), data);
        }
        public void TableBottom()
        {
            Console.Write("╚");
            Console.Write(Line(size[0]));
            for (int j = 0; j < colCount - 1; j++)
            {
                Console.Write("╩"); Console.Write(Line(size[j + 1]));
            }
            Console.WriteLine("╝");
        }
    }
}
