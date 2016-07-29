namespace Task1
{
    /// <summary>
    ///     Класс столбцов которые содержит таблица
    /// </summary>
    public class Column
    {

        private int width;

        public Column() {}

        public Column(string title, int width, Align align = Align.Center)
        {
            Title = title;
            Width = width;
            Align = align;
        }

        public string Title { get; set; }

        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0 && value < 100)
                    width = value;
            }
        }

        public Align Align { get; set; }
    }
}