using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Racing
{
    public delegate void CF(object sender, Car c);

    public class Track
    {
        private List<TrackCars> cars = new List<TrackCars>();
        private int length;

        public Track(int length = 1000)
        {
            Length = length;
        }

        public int Length
        {
            get { return length; }
            set
            {
                if (value > 0)
                {
                    length = value;
                }
            }
        }

        public List<TrackCars> Cars
        {
            get { return cars; }
        }

        public event CF CarFinished;

        private void OnCarFinish(Car c)
        {
            if (CarFinished != null)
                CarFinished(this, c);
        }

        public void AddCar(Car car)
        {
            cars.Add(new TrackCars(car));
        }

        public void StartRace()
        {
            while (cars.Any(x => x.Car.Status == CarStatus.Moving || x.Car.Status == CarStatus.Ready))
            {
                foreach (var c in cars)
                {
                    c.Car.Tick();
                    if (c.Car.Status == CarStatus.Moving)
                    {
                        c.Position += c.Car.CurrentSpeed;
                    }
                    if (c.Position >= Length && c.Car.Status != CarStatus.Finished)
                    {
                        c.Position = Length;
                        c.Car.Finish();
                        OnCarFinish(c.Car);
                    }
                }
                Console.Clear();
                DrawTrack();
                DrawStats();
                Thread.Sleep(200);
            }
        }

        private static char NumberToChar(int number)
        {
            String str = "⓿❶❷❸❹❺❻❼❽❾❿⓫⓬⓭⓮⓯⓰⓱⓲⓳⓴";
            if (number <= str.Length)
                return str[number];
            return str[0];
        }

        public void DrawTrack()
        {
            int consoleWidth = Console.WindowWidth - 1;
            StringBuilder border = new StringBuilder(consoleWidth);
            StringBuilder track = new StringBuilder(consoleWidth);
            border.Append('-', consoleWidth);
            Console.WriteLine(border);
            for (int i = 0; i < cars.Count; i++)
            {
                var c = cars[i];
                track.Clear();
                track.Append(' ', consoleWidth);
                int p = (int) (c.Position * (consoleWidth - 1) / Length);
                if (c.Car.Status == CarStatus.Destroyed)
                {
                    track[p] = '✶';
                }
                else
                {
                    track[p] = NumberToChar(i + 1);
                }
                Console.ForegroundColor = c.Car.Color;
                Console.WriteLine(track);
                Console.ResetColor();
                Console.WriteLine(border);
            }
        }

        public void DrawStats()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var c = cars[i];
                Console.ForegroundColor = c.Car.Color;
                Console.Write(NumberToChar(i + 1));
                Console.ResetColor();
                Console.WriteLine(" - {0}" +
                                  "MaxSpeed = {1,6:F}\t" +
                                  "Acceleration = {2,6:F}\t" +
                                  "CurrentSpeed = {3,6:F}\t" +
                                  "Status = {4}",
                    c.Car.Name.PadRight(20),
                    c.Car.MaxSpeed,
                    c.Car.Acceleration,
                    c.Car.CurrentSpeed,
                    c.Car.Status);
            }
        }
    }
}