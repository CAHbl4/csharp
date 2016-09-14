using System.Collections.Generic;

namespace TransportManager.BL
{
    public abstract class BasicTransport : ITransport
    {
        public abstract string Type { get; }

        public abstract int GetMaxSeats(SeatType type);

        public abstract IEnumerable<SeatType> GeSeatTypes();
    }
}