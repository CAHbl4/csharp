using System;
using System.Collections.Generic;

namespace TransportManager.BL
{
    public class Bus : ITransport
    {
        private readonly Dictionary<SeatType, int> _maxSeats = new Dictionary<SeatType, int>();

        public void AddSeats(SeatType seatType, int count)
        {
            if (!_maxSeats.ContainsKey(seatType))
                _maxSeats.Add(seatType, count);
            else _maxSeats[seatType] += count;
        }

        public int CompareTo(ITransport other)
        {
            throw new NotImplementedException();
        }

        public string Type { get; set; }

        public int GetMaxSeats(SeatType type)
        {
            if (_maxSeats.ContainsKey(type))
                return _maxSeats[type];
            return 0;
        }
    }
}