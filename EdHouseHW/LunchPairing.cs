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
        private string file;
        private Driver driverOne;
        private Driver driverTwo;
        public Point lunchCords { get; private set; }

        public LunchPairing(string file)
        {
            this.file = file;
        }
        public LunchPairing() { }

        private bool PairDrivers() 
        {
            lunchCords = new Point(0, 0);
            return true;
        }


        private bool ReadFileInput()
        {
            try
            {
                // open file with input
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    // get lunch interval
                    string[] firstLine = sr.ReadLine()?.Split('-');
                    int[] lunchInterval = new int[2];
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

                    driverOne.PrintDriver();
                    driverTwo.PrintDriver();

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


        public bool FindLunchCords()
        {
            if (!ReadFileInput() || !PairDrivers())
            {
                Program.ErrorMsg("could not find a place for lunch");
                return false;
            }

            return true;
        }

    }
}
