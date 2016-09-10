using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    abstract class LandTransport : ITransport
    {
        protected int _flightNumber;
        readonly double[] _cost;

        public LandTransport(int costCount) : this(0, null, null, costCount)
        {

        }

        public LandTransport(int flightNumber, string departure, string arrive, int costCount)
        {
            _flightNumber = flightNumber;
            Departure = departure;
            Arrive = arrive;
            _cost = new double[costCount];
        }


        public virtual int FreeSeats
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public string Departure
        {
            get; set;
        }

        public string Arrive
        {
            get; set;
        }

        public virtual string Type
        {
            get
            {
                return GetType().Name;
            }
        }

        public double this[int i]
        {
            get
            {
                return _cost[i];
            }
            set
            {
                _cost[i] = value;
            }
        }

        public abstract void ShowInfo();

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            ITransport other = obj as ITransport;
            if (obj != null)
                return this.GetType().Name.CompareTo(other.GetType().Name);
            else throw new ArgumentException("Object is not a Transport");
        }
    }
}
