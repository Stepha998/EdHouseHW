using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouseHW
{
    internal class LunchPairing
    {
        private Driver driverOne;
        private Driver driverTwo;
        private int[] lunchInterval = new int[2];
        public Point lunchCords { get; private set; }


        private bool PairDrivers() 
        {
            for (int i = 0; i < driverOne.lunchTrack.TrackList.Count; i++)
            {
                if (driverOne.lunchTrack.TrackList[i] == driverTwo.lunchTrack.TrackList[i])
                {
                    lunchCords = driverOne.lunchTrack.TrackList[i];
                    return true;
                }
            }
            Program.ErrorMsg("could not find a place for lunch");
            return false;
        }


        private bool ReadInput(string file)
        {
            try
            {
                // open file with input
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    // get lunch interval
                    string[] firstLine = sr.ReadLine()?.Split('-');
                    if (firstLine == null || firstLine.Length != 2 || !int.TryParse(firstLine[0], out lunchInterval[0]) || !int.TryParse(firstLine[1], out lunchInterval[1]))
                    {
                        Program.ErrorMsg("lunch break interval specified incorrectly");
                        return false;
                    }

                    string[] directionsOne = sr.ReadLine()?.Split(',');
                    Track trackOne = new Track();
                    string[] directionsTwo = sr.ReadLine()?.Split(',');
                    Track trackTwo = new Track();
                    if (!trackTwo.CreateTrack(directionsOne) || !trackOne.CreateTrack(directionsTwo))
                    {
                        return false;
                    }

                    driverOne = new Driver(trackOne, lunchInterval);
                    driverTwo = new Driver(trackTwo, lunchInterval);

                    if (!driverOne.CreateLunchTrack() || !driverTwo.CreateLunchTrack())
                    {
                        return false;
                    }


                    return true;
                }
            }
            catch (FileLoadException)
            {
                throw new FileLoadException("file could not be loaded");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("file could not be loaded");
            }
        }

        private bool ReadInput()
        {
            // get lunch interval
            string[] firstLine = Console.ReadLine().Split('-');
            if (firstLine == null || firstLine.Length != 2 || !int.TryParse(firstLine[0], out lunchInterval[0]) || !int.TryParse(firstLine[1], out lunchInterval[1]))
            {
                Program.ErrorMsg("lunch break interval specified incorrectly");
                return false;
            }

            string[] directionsOne = Console.ReadLine().Split(',');
            Track trackOne = new Track();
            string[] directionsTwo = Console.ReadLine().Split(',');
            Track trackTwo = new Track();
            if (!trackTwo.CreateTrack(directionsOne) || !trackOne.CreateTrack(directionsTwo))
            {
                return false;
            }

            driverOne = new Driver(trackOne, lunchInterval);
            driverTwo = new Driver(trackTwo, lunchInterval);

            if (!driverOne.CreateLunchTrack() || !driverTwo.CreateLunchTrack())
            {
                return false;
            }


            return true;
        }


        public bool FindLunchCords(string file)
        {
            if (!ReadInput(file) || !PairDrivers())
            {
                return false;
            }

            return true;
        }
        public bool FindLunchCords()
        {
            if (!ReadInput() || !PairDrivers())
            {
                return false;
            }

            return true;
        }
    }
}
