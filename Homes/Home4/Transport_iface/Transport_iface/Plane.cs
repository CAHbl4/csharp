using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    enum PlaneSeatTypes
    {
        First = 0,
        Business = 1,
        Economy = 2
    }
    class Plane : ITransport
    {
        double[] _cost;
        int _freeSeats;
        int _flightNumber;

        public Plane() : this (0, null, null)
        {
            
        }

        public Plane(int flightNumber, string departure, string arrive)
        {
            _flightNumber = flightNumber;
            Departure = departure;
            Arrive = arrive;
            _cost = new double[Enum.GetNames(typeof(PlaneSeatTypes)).Length];
        }

        public double this[int i]
        {
            get
            {
                return _cost[i];
            }
        }

        public double this[PlaneSeatTypes t]
        {
            get { return _cost[(int)t]; }
            set { _cost[(int)t] = value; }
        }


        public string Arrive
        {
            get; set;          
        }

        public string Departure
        {
            get; set;
        }

        public int FreeSeats
        {
            get
            {
                return _freeSeats;
            }
        }

        public string Type
        {
            get
            {
                return GetType().Name;
            }
        }

        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public void SetFreeSeats(int seats)
        {
            if (seats >= 0)
                _freeSeats = seats;
            else throw new ArgumentException("Number must be positive");
        }

        public void ShowInfo()
        {
            if (FreeSeats == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Type + "\t" + _flightNumber + "\t" + Departure + "\t" + Arrive + "\t" + FreeSeats);
            Console.ResetColor();
        }
    }
}
