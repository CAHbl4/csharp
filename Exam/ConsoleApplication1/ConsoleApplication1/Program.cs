using System;
using BL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MoviesCollection<AbstractMovie> collection = new MoviesCollection<AbstractMovie>();
            CSVFileRepository csvFileRepository = new CSVFileRepository(@"movies.csv");
            foreach (AbstractMovie movie in csvFileRepository.Load())
                collection.Add(movie);

            foreach (AbstractMovie movie in collection)
                Console.WriteLine(movie);

            decimal sum = 0;
            foreach (AbstractMovie movie in collection)
            {
                TVShow show = movie as TVShow;
                if (show == null)
                    continue;
                if (show)
                    sum += show.GetCost();
            }
            Console.WriteLine($"Sum = {sum}");

            foreach (AbstractMovie movie in collection.Find(x => x.Director == "Director1"))
                Console.WriteLine(movie);

            Console.WriteLine("---Sort---");

            MovieCostSort comparer = new MovieCostSort();
            AbstractMovie[] sort = collection.ToArray();
            Array.Sort(sort, comparer);

            foreach (AbstractMovie movie in sort)
                Console.WriteLine(movie);

            SOAPFileRepository soapFileRepository = new SOAPFileRepository(@"movies.soap");
            soapFileRepository.Save(collection.ToArray());

            Console.WriteLine("Matuzov " + DateTime.Now);
        }
    }
}