using System;
using System.Collections.Generic;

namespace TransportManager.BL
{
    public interface ITransport: IComparable<ITransport>
    {
        string Type { get; set; }
        int GetMaxSeats(SeatType type);
    }
}