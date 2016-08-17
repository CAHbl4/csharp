using System;

namespace Racing
{
    public class Car
    {
        private double acceleration;
        private double maxSpeed;

        public Car(string name, double maxSpeed = 0, double acceleration = 0)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            CurrentSpeed = 0;
            Status = CarStatus.Ready;
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
                    if (CurrentSpeed < maxSpeed/2)
                    {
                        CurrentSpeed += acceleration;
                    }
                    else if (CurrentSpeed < maxSpeed)
                    {
                        CurrentSpeed += maxSpeed/(maxSpeed - CurrentSpeed)*acceleration;
                    }
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
            return Name[1].ToString();
        }
    }
}