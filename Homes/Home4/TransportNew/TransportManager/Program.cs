using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManager.BL;

namespace TransportManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus { Type = "Bus"};
            SeatType busSoftSeat = new SeatType {Name = "Soft"};
            SeatType busHardSeat = new SeatType {Name = "Hard"};
            bus.AddSeats(busSoftSeat, 10);
            bus.AddSeats(busHardSeat, 15);
            Flight flight = new Flight(bus) {FlightNumber = "256", Departure = "Minsk", Destination = "Gomel"};
            flight.SetTicketCost(busSoftSeat,(decimal) 25.5);
            flight.SetTicketCost(busHardSeat,(decimal) 20.5);
            flight.BuyTicket(busHardSeat, 10);
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",flight.Type,flight.FlightNumber,flight.Departure,flight.Destination,flight.GetFreeSeats());
            Console.ReadKey();
        }
    }
}
