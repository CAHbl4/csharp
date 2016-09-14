using System.Collections.Generic;
using System.Linq;

namespace TransportManager.BL
{
    public class Train : BasicTransport
    {
        private readonly List<Coach> _coaches;

        public Train()
        {
            _coaches = new List<Coach>();
        }

        public override string Type => "Train";

        public override int GetMaxSeats(SeatType type)
        {
            return _coaches.Where(x => x.SeatType == type).Sum(x => x.SeatCount);
        }

        public override IEnumerable<SeatType> GeSeatTypes()
        {
            return _coaches.Select(x => x.SeatType).Distinct();
        }

        public void AddCoach(Coach coach)
        {
            _coaches.Add(coach);
        }
    }
}