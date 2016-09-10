using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    enum TrainSeatTypes
    {
        Lux = 0,
        Compartment = 1,
        Reserved = 2,
        Common = 3
    }
    class Train : LandTransport
    {
        int[] _carriages;
        public Train() : this(1)
        {
        }
        public Train(int carriagesCount) :
            this(0, null, null, carriagesCount)
        {

        }

        public Train(int flightNumber, string departure, string arrive, int carriagesCount) :
            base(flightNumber, departure, arrive, Enum.GetNames(typeof(TrainSeatTypes)).Length)
        {
            _carriages = new int[carriagesCount];
        }

        public int GetCarriagesCount()
        {
            return _carriages.Length;
        }

        public void SetCostType(TrainSeatTypes type, double cost)
        {
            base[(int)type] = cost;
        }

        public void SetFreeSeats(int carriageNumber, int seats)
        {
            if (carriageNumber >= 0 && carriageNumber < _carriages.Length)
            {
                if (seats >= 0)
                    _carriages[carriageNumber] = seats;
                else throw new ArgumentException("Number must be positive");
            }
            else throw new ArgumentException("Wrong carriage number");
        }

        public double this[TrainSeatTypes t]
        {
            get { return base[(int)t]; }
            set { base[(int)t] = value; }
        }

        public override int FreeSeats
        {
            get
            {
                return _carriages.Sum();
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
