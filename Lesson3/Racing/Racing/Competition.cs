using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Racing
{
    public class Competition
    {
        private Track track;
        private List<Car> result = new List<Car>();
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

        public void DrawResults()
        {
            for (int i = 0; i < (result.Count < 3 ?result.Count:3); i++)
            {
                StringBuilder str = new StringBuilder();
                switch (i)
                {
                    case 0:
                        str.Append("1st place - ");
                        break;
                    case 1:
                        str.Append("2nd place - ");
                        break;
                    case 2:
                        str.Append("3rd place - ");
                        break;
                }
                str.Append(result[i]);
                Console.WriteLine(str);
            }
        }

    }
}