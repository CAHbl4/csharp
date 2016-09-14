using System;

namespace TransportManager.BL
{
    public interface IFlight: IFlightInfo, ITicketService, IComparable<IFlight>
    {
        
    }
}