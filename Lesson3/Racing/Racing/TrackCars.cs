namespace Racing
{
    public class TrackCars
    {
        public TrackCars(Car car)
        {
            Car = car;
            Position = 0;
        }

        public Car Car { get; set; }

        public double Position { get; set; }
    }
}