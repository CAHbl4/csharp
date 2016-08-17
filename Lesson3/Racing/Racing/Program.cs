using System;

namespace Racing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var competition = new Competition(new Track(2000));
            competition.Track.AddCar(new Car("car1", 50, 10));
            competition.Track.AddCar(new Car("car2", 80, 15));
            competition.Track.AddCar(new Car("car3", 100, 20));
            competition.Start();

            Console.ReadKey();
        }
    }
}