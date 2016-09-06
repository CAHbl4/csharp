using System;

namespace Racing
{
    public class Car
    {
        private double acceleration;
        private double maxSpeed;
        private ConsoleColor color;
        private static Random rnd = new Random();

        public Car(string name, double maxSpeed = 0, double acceleration = 0)
        {
            
            color = (ConsoleColor) rnd.Next(1, 15);
            Name = name;
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            CurrentSpeed = 0;
            Status = CarStatus.Ready;
        }

        public ConsoleColor Color
        {
            get { return color; }
        }

        public CarStatus Status { get; private set; }

        public double CurrentSpeed { get; private set; }

        public string Name { get; set; }

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0 && value < Consts.CarMaxSpeed)
                {
                    maxSpeed = value;
                }
                else
                {
                    throw new Exception("Is it a plane?");
                }
            }
        }

        public double Acceleration
        {
            get { return acceleration; }
            set
            {
                if (value > 0 && value < Consts.CarMaxAcceleration)
                {
                    acceleration = value;
                }
                else
                {
                    throw new Exception("Is it a plane?");
                }
            }
        }

        public void Tick()
        {
            switch (Status)
            {
                case CarStatus.Ready:
                    Status = CarStatus.Moving;
                    break;
                case CarStatus.Moving:
                    if (rnd.Next(0, 10000)/100D < Consts.ChanceToCrash)
                    {
                        Status = CarStatus.Destroyed;
                        CurrentSpeed = 0;
                    }
                    else if (rnd.Next(0,99) < Consts.DeccelerateChance)
                    {
                        double penalty = (100 - rnd.Next(1, Consts.MaxDeccelerate)) / 100D;
                        CurrentSpeed *= penalty;
                    }
                    else if (rnd.Next(0, 99) < Consts.BonusAccelerateChance)
                    {
                        double bonus = (100 + rnd.Next(1, Consts.MaxAccelerateBonus)) / 100D;
                        CurrentSpeed *= bonus;
                    }
                    else if (CurrentSpeed < maxSpeed / 2)
                    {
                        CurrentSpeed += acceleration;
                    }
                    else if (CurrentSpeed <= maxSpeed)
                    {
                        CurrentSpeed += acceleration * (maxSpeed - CurrentSpeed) / maxSpeed;
                    }
                    if (CurrentSpeed > MaxSpeed)
                        CurrentSpeed = MaxSpeed;
                    break;
            }
        }

        public void Finish()
        {
            Status = CarStatus.Finished;
            CurrentSpeed = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}