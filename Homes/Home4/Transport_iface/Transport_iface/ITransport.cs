using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    interface ITransport: IComparable
    {
        int FreeSeats { get; }

        int FlightNumber { get; set; }
        string Departure { get; set; }
        string Arrive { get; set; }
        string Type { get; }

        void ShowInfo();
        double this[int i] { get; }

    }
}
