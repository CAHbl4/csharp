using System.Collections;
using System.Collections.Generic;

namespace Racing
{
    public class Competition
    {
        private Track track;
        private Car winner;
        private List<Car> result;
        public Track Track
        {
            get { return track; }
        }

        public Competition(Track track)
        {
            this.track = track;
            track.CarFinished += new CF(CarFinished);
        }

        private void CarFinished(object sender,Car c)
        {
            result.Add(c);
        }

        public void Start()
        {
            track.StartRace();
        }

    }
}