using System;

namespace BL
{
    [Serializable]
    public class Action: AbstractMovie
    {
        public string ActionDirector { get; set; }

        decimal tricksCost;
        decimal filmingCost;

        public Action()
        {
        }

        public Action(string name, string director, decimal tricksCost, decimal filmingCost, string actionDirector) : base(name, director)
        {
            TricksCost = tricksCost;
            FilmingCost = filmingCost;
            ActionDirector = actionDirector;
        }

        public decimal TricksCost
        {
            get { return tricksCost; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Cost should be positive");
                tricksCost = value;
            }
        }

        public decimal FilmingCost
        {
            get { return filmingCost; }
            set
            {
                if (value < 0 ) throw new ArgumentOutOfRangeException("Cost should be positive");
                filmingCost = value;
            }
        }

        public override string Genre => "Action";
        public override decimal GetCost()
        {
            return tricksCost + filmingCost;
        }

        public override string ToString()
        {
            return $"{base.ToString()};{nameof(ActionDirector)}: {ActionDirector}";
        }
    }
}