using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BL
{
    public class CSVFileRepository : IRepository
    {
        readonly string filePath;

        public CSVFileRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(IEnumerable<AbstractMovie> movies)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);
            using (StreamWriter writer = new StreamWriter(File.OpenWrite(filePath)))
            {
                foreach (AbstractMovie movie in movies)
                    writer.Write(Serialize(movie));
            }
        }

        public IEnumerable<AbstractMovie> Load()
        {
            List<AbstractMovie> result = new List<AbstractMovie>();
            using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    result.Add(Deserialize(line));
                }
            }
            return result.ToArray();
        }

        public static AbstractMovie Deserialize(string line)
        {
            string[] fields = line.Split(';');
            switch (fields[0])
            {
                case "TV Show":
                    return new TVShow(fields[1], fields[2], decimal.Parse(fields[3]), int.Parse(fields[4]));
                case "Action":
                    return new Action(fields[1], fields[2], decimal.Parse(fields[3]), decimal.Parse(fields[4]),
                        fields[5]);
                default:
                    return null;
            }
        }

        public static string Serialize(AbstractMovie movie)
        {
            StringBuilder result = new StringBuilder();
            switch (movie.Genre)
            {
                case "TV Shov":
                    TVShow show = movie as TVShow;
                    if (show == null) throw new ArgumentException();
                    result.Append(show.Genre);
                    result.Append(';');
                    result.Append(show.Name);
                    result.Append(';');
                    result.Append(show.Director);
                    result.Append(';');
                    result.Append(show.EpisodePrice);
                    result.Append(';');
                    result.Append(show.EpisodesCount);
                    break;
                case "Action":
                    Action action = movie as Action;
                    if (action == null) throw new ArgumentException();
                    result.Append(action.Genre);
                    result.Append(';');
                    result.Append(action.Name);
                    result.Append(';');
                    result.Append(action.Director);
                    result.Append(';');
                    result.Append(action.TricksCost);
                    result.Append(';');
                    result.Append(action.ActionDirector);
                    result.Append(';');
                    result.Append(action.ActionDirector);
                    break;
            }
            return result.ToString();
        }
    }
}