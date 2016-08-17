using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Racing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.OutputEncoding = Encoding.UTF8;
            var competition = new Competition(new Track(2000));
            competition.Track.AddCar(new Car("Ferrari", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Williams", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Mercedes", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Red Bull Racing", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("McLaren", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Force India", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Toro Rosso", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Hass F1 Team", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Renault", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Manor Racing", rnd.Next(94, 103), rnd.Next(8, 11)));
            competition.Track.AddCar(new Car("Sauber", rnd.Next(94, 103), rnd.Next(8, 11)));

            Console.SetWindowSize(Console.WindowWidth, competition.Track.Cars.Count * 3 + 2);
            competition.Track.DrawTrack();
            competition.Track.DrawStats();
            Console.ReadKey();
            competition.Start();
            Console.WriteLine();
            competition.DrawResults();

            Console.ReadKey();
        }
    }
}