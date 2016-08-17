using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Racing
{
    public delegate void CF(object sender, Car c);
    public class Track
    {
        private List<TrackCars> cars;
        private int length;
        public event CF CarFinished;

        protected void OnCarFinish(Car c)
        {
            if (CarFinished != null)
                CarFinished(this, c);
        }

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

        public void AddCar(Car car)
        {
            cars.Add(new TrackCars(car));
        }

        public void StartRace()
        {
            while (cars.Any(x => x.Car.Status == CarStatus.Moving && x.Car.Status == CarStatus.Ready))
            {
                foreach (var c in cars)
                {
                    c.Car.Tick();
                    if (c.Car.Status == CarStatus.Moving)
                    {
                        c.Position += c.Car.CurrentSpeed;
                    }
                    if (c.Position >= Length)
                    {
                        c.Car.Finish();
                        OnCarFinish(c.Car);
                        Console.WriteLine("{0} Finished",c.Car.Name);
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}