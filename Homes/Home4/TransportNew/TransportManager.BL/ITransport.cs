using System;
using System.Collections.Generic;

namespace TransportManager.BL
{
    public interface ITransport: IComparable<ITransport>
    {
        string Type { get;}
        int GetMaxSeats(SeatType type);

        IEnumerable<SeatType> GeSeatTypes();
    }
}