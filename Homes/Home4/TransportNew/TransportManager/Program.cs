using System;
using System.Collections.Generic;
using System.Linq;
using TableGenerator;
using TransportManager.BL;

namespace TransportManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bus bus = new Bus();
            SeatType busSoftSeat = new SeatType {Name = "Soft"};
            SeatType busHardSeat = new SeatType {Name = "Hard"};

            bus.AddSeats(busSoftSeat, 10);
            bus.AddSeats(busHardSeat, 15);

            Train train = new Train();
            SeatType trainCommonSeat = new SeatType() { Name = "Common" };
            SeatType trainLuxSeat = new SeatType() { Name = "Common" };

            train.AddCoach(new Coach(trainCommonSeat, 30));
            train.AddCoach(new Coach(trainCommonSeat, 45));
            train.AddCoach(new Coach(trainLuxSeat, 10));

            Plane plane = new Plane();
            SeatType planeFirstClass = new SeatType() {Name = "First"};
            SeatType planeEconomyClass = new SeatType() {Name = "Economy"};
            SeatType planeBusinessClass = new SeatType() {Name = "Business"};

            plane.AddSeats(planeFirstClass, 10);
            plane.AddSeats(planeEconomyClass, 15);
            plane.AddSeats(planeBusinessClass, 20);

            var flights = new List<IFlight>
            {
                new Flight(bus) {FlightNumber = "256", Departure = "Minsk", Destination = "Gomel"},
                new Flight(train) {FlightNumber = "866", Departure = "Minsk", Destination = "Moscow"},
                new Flight(plane) {FlightNumber = "AC-476", Departure = "Tokyo", Destination = "New-York City"}
            };
            flights[0].SetTicketCost(busSoftSeat, (decimal) 25.5);
            flights[0].SetTicketCost(busHardSeat, (decimal) 20.5);
            flights[0].BuyTicket(busHardSeat, 10);

            flights[1].SetTicketCost(trainCommonSeat, (decimal) 40.4);
            flights[1].SetTicketCost(trainLuxSeat, (decimal) 60.8);
            flights[1].BuyTicket(trainCommonSeat, 18);
            flights[1].BuyTicket(trainLuxSeat, 4);

            flights[2].SetTicketCost(planeFirstClass, 1500);
            flights[2].SetTicketCost(planeBusinessClass, 1100);
            flights[2].SetTicketCost(planeEconomyClass, 800);
            flights[2].BuyTicket(planeFirstClass, 10);
            flights[2].BuyTicket(planeEconomyClass, 15);
            flights[2].BuyTicket(planeBusinessClass, 20);

            InfoBoard.DrawFlightBoard(flights);
            InfoBoard.DrawTicketsInfo(flights.First(x=> x.FlightNumber == "256"));

            Console.ReadKey();
        }
    }
}