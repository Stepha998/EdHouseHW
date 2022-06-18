using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouseHW
{
    internal class Driver
    {
        public Track track { get; }
        private int[] lunchInterval;
        public Track lunchTrack { get; }

        public Driver(Track track, int[] lunchInterval)
        {
            this.track = track;
            this.lunchInterval = lunchInterval;
            this.lunchTrack = new Track();
        }
        

        public bool CreateLunchTrack()
        {
            if (!lunchTrack.CreateLunchTrack(track, lunchInterval[0], lunchInterval[1]))
            {
                return false;
            }
            return true;
        }
    }
}
