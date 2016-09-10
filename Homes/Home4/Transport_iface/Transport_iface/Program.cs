using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_iface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Пытался сделать почти в точности как описано в задании, получилось не очень, сделаю вторую версию по своему.

            Bus bus = new Bus(245, "Gomel", "Minsk");
            bus.SetFreeSeats(10);
            bus[BusSeatTypes.Hard] = 10;
            bus[BusSeatTypes.Soft] = 15;

            Train train = new Train(986, "Minsk", "Moscow", 7);
            for (int i = 0; i < train.GetCarriagesCount(); i++)
            {
                train.SetFreeSeats(i, i * 10 + i);
            }
            train[TrainSeatTypes.Common] = 20;
            train[TrainSeatTypes.Reserved] = 30;
            train[TrainSeatTypes.Compartment] = 40;
            train[TrainSeatTypes.Lux] = 40;

            Plane plane = new Plane(777, "Moscow", "New-York");
            plane[PlaneSeatTypes.Economy] = 100;
            plane[PlaneSeatTypes.Business] = 150;
            plane[PlaneSeatTypes.First] = 200;

            ITransport[] t = new ITransport[] { bus, train, plane};

            foreach (var item in t)
            {
                item.ShowInfo();
            }

            Console.WriteLine();

            Console.WriteLine("Flight Number\t" + PlaneSeatTypes.Business);
            ShowCost(t[2], (int)PlaneSeatTypes.Business);

            Console.ReadKey();
        }

      static void ShowCost(ITransport t , int i)
        {
            Console.WriteLine(t.FlightNumber + "\t\t" + t[i]);
        }
    }
}
