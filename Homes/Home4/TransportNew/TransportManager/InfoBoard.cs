using System;
using System.Collections.Generic;
using TableGenerator;
using TransportManager.BL;

namespace TransportManager
{
    public static class InfoBoard
    {
        public static void DrawFlightBoard(IEnumerable<IFlight> flights)
        {
            Table infoBoard = new Table();
            infoBoard.AddColumn("Flight number", 13, Align.Left);
            infoBoard.AddColumn("Type", 10, Align.Left);
            infoBoard.AddColumn("Departure", 20, Align.Left);
            infoBoard.AddColumn("Destination", 20, Align.Left);
            infoBoard.AddColumn("Free seats", 10, Align.Left);

            infoBoard.DrawHead();
            foreach (var flight in flights)
            {
                ConsoleColor color = flight.GetTotalFreeSeats() == 0 ? ConsoleColor.Red : Console.ForegroundColor;
                infoBoard.DrawRow(color, flight.FlightNumber, flight.Type, flight.Departure, flight.Destination,
                    flight.GetTotalFreeSeats().ToString());
            }

            infoBoard.DrawFooter();
        }

        public static void DrawTicketsInfo(IFlight flight)
        {
            Table tickeTable = new Table(String.Format("Price table for {0}", flight.Type));
            tickeTable.AddColumn("Flight number", 13, Align.Left);
            List<string> row = new List<string>();
            row.Add(flight.FlightNumber);

            foreach (SeatType seatType in flight.GetSeatTypes())
            {
                tickeTable.AddColumn(seatType.Name,20,Align.Right);
                row.Add(flight.GetTicketCost(seatType).ToString());
            }
            tickeTable.DrawHead();
            tickeTable.DrawRow(row.ToArray());
            tickeTable.DrawFooter();
        }
    }
}