using System.Collections.Generic;

namespace TransportManager.BL
{
    public class Plane : BasicTransport
    {
        private readonly Dictionary<SeatType, int> _maxSeats = new Dictionary<SeatType, int>();

        public override string Type => "Plane";

        public void AddSeats(SeatType seatType, int count)
        {
            if (!_maxSeats.ContainsKey(seatType))
                _maxSeats.Add(seatType, count);
            else _maxSeats[seatType] += count;
        }

        public override int GetMaxSeats(SeatType type)
        {
            return _maxSeats.ContainsKey(type) ? _maxSeats[type] : 0;
        }

        public override IEnumerable<SeatType> GeSeatTypes()
        {
            return _maxSeats.Keys;
        }
    }
}