using System;

namespace BL
{
    [Serializable]
    public class TVShow : AbstractMovie
    {
        decimal episodePrice;
        int episodesCount;

        public TVShow()
        {
        }

        public TVShow(string name, string director, decimal episodePrice, int episodesCount) : base(name, director)
        {
            EpisodePrice = episodePrice;
            EpisodesCount = episodesCount;
        }

        public int EpisodesCount
        {
            get { return episodesCount; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Count should be greater than 0");
                episodesCount = value;
            }
        }

        public decimal EpisodePrice
        {
            get { return episodePrice; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Price should be greater than 0");
                episodePrice = value;
            }
        }

        public override string Genre => "TV Show";

        public override decimal GetCost()
        {
            return episodesCount * episodePrice;
        }

        public static bool operator true(TVShow movie)
        {
            return movie.episodesCount > 3;
        }

        public static bool operator false(TVShow movie)
        {
            return movie.episodesCount <= 3;
        }

        public override string ToString()
        {
            return $"{base.ToString()};{EpisodesCount}";
        }
    }
}