using System.Collections.Generic;

namespace TransportManager.BL
{
    public interface ITicketService
    {
        IEnumerable<SeatType> GetSeatTypes();
        int GetFreeSeats(SeatType seatType);
        decimal GetTicketCost(SeatType seatType);
        void SetTicketCost(SeatType seatType, decimal cost);
        bool BuyTicket(SeatType seatType, int count);
    }
}