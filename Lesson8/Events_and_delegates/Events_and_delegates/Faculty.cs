namespace Events_and_delegates
{
    public delegate void FN(string name);
    public class Faculty
    {
        private string name;
        private string decan;
        private string phone;

        public event FN NameChanged;

        public Faculty()
        {
        }

        public Faculty(string name, string decan, string phone)
        {
            this.name = name;
            this.decan = decan;
            this.phone = phone;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NameChanged(value);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Decan: {1}, Phone: {2}", name, decan, phone);
        }
    }
}