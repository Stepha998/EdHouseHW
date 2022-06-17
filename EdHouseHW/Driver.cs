﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouseHW
{
    internal class Driver
    {
        public Track track { get; }
        private readonly int[] lunchInterval;
        public Track lunchTrack { get; }
        public bool HasLunchPartner;

        public Driver(Track track, int[] lunchInterval)
        {
            this.track = track;
            this.lunchInterval = lunchInterval;
            this.lunchTrack = new Track(track, lunchInterval[0], lunchInterval[1]);
            this.HasLunchPartner = false;
        }
        
        public void PrintDriver()
        {
            string x = track.TrackList[0] + ", " + track.TrackList[^1];
            
            string z = lunchTrack.TrackList[0] + ", " + lunchTrack.TrackList[^1];

            Console.WriteLine($"{x}, {z}, lunch brake: {lunchInterval[0]} {lunchInterval[1]}");
        }
    }
}
