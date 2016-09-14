using System.Collections.Generic;
using System.Linq;

namespace TransportManager.BL
{
    public class Flight : IFlight
    {
        private readonly Dictionary<SeatType, int> _freeSeats;
        private readonly Dictionary<SeatType, decimal> _seatTypes;
        private readonly ITransport _transport;

        public Flight(ITransport transport)
        {
            _transport = transport;
            _seatTypes = new Dictionary<SeatType, decimal>();
            _freeSeats = new Dictionary<SeatType, int>();
            foreach (SeatType seatType in _transport.GeSeatTypes())
            {
                _seatTypes.Add(seatType, 0);
                _freeSeats.Add(seatType, _transport.GetMaxSeats(seatType));
            }
        }

        public string Type => _transport.Type;

        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public IEnumerable<SeatType> GetSeatTypes()
        {
            return _seatTypes.Keys;
        }

        public int GetFreeSeats(SeatType seatType)
        {
            return _freeSeats[seatType];
        }

        public int GetTotalFreeSeats()
        {
            return _freeSeats.Sum(x => x.Value);
        }

        public decimal GetTicketCost(SeatType seatType)
        {
            return _seatTypes[seatType];
        }

        public void SetTicketCost(SeatType seatType, decimal cost)
        {
            if (!_seatTypes.ContainsKey(seatType))
            {
                _seatTypes.Add(seatType, cost);
                _freeSeats.Add(seatType, _transport.GetMaxSeats(seatType));
            }
            else _seatTypes[seatType] = cost;
        }

        public bool BuyTicket(SeatType seatType, int count)
        {
            if (!_freeSeats.ContainsKey(seatType) || (_freeSeats[seatType] - count < 0)) return false;
            _freeSeats[seatType] -= count;
            return true;
        }
    }
}