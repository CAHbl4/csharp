using System;

namespace BL
{
    [Serializable]
    public abstract class AbstractMovie
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public abstract string Genre { get; }

        protected AbstractMovie()
        {
        }

        protected AbstractMovie(string name, string director)
        {
            Name = name;
            Director = director;
        }

        public abstract decimal GetCost();

        public override string ToString()
        {
            return $"{Name};{Director};{Genre};{GetCost()}";
        }
    }
}