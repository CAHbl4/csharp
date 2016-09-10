using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    enum BusSeatTypes
    {
        Soft = 0,
        Hard = 1
    }
    class Bus : LandTransport
    {
        int _freeSeats;

        public Bus() : base(Enum.GetNames(typeof(BusSeatTypes)).Length)
        {
        }

        public Bus(int flightNumber, string departure, string arrive) :
            base(flightNumber, departure, arrive, Enum.GetNames(typeof(BusSeatTypes)).Length)
        {
        }

        public override int FreeSeats
        {
            get
            {
                return _freeSeats;
            }
        }

        public void SetFreeSeats(int seats)
        {
            if (seats >= 0)
                _freeSeats = seats;
            else throw new ArgumentException("Number must be positive");
        }

        public void SetCostType(BusSeatTypes type, double cost)
        {
            base[(int)type] = cost;
        }

        public double this[BusSeatTypes t]
        {
            get
            {
                return base[(int)t];
            }
            set
            {
                base[(int)t] = value;
            }
        }
        public override void ShowInfo()
        {
            if (FreeSeats == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Type + "\t" + _flightNumber + "\t" + Departure + "\t" + Arrive + "\t" + FreeSeats);
            Console.ResetColor();
        }
    }
}
