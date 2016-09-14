using System;

namespace TransportManager.BL
{
    public class Coach
    {
        private int _seatCount;

        public Coach() : this(null, 0)
        {
        }

        public Coach(SeatType seatType, int seatCount)
        {
            SeatType = seatType;
            SeatCount = seatCount;
        }

        public SeatType SeatType { get; set; }

        public int SeatCount
        {
            get { return _seatCount; }
            set
            {
                if (value >= 0)
                    _seatCount = value;
                else
                    throw new ArgumentException("Count should be positive");
            }
        }
    }
}