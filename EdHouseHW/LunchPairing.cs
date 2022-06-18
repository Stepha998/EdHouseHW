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
        private Point lunchCords;

        public LunchPairing(string file)
        {
            this.file = file;
        }
        public LunchPairing() { }

        private Point PairDrivers()
        {
            return new Point(0, 0);
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
                        Program.ErrorMsg("lunch brake interval specified incorrectly");
                    }

                    string[] directions;
                    directions = sr.ReadLine()?.Split(',');
                    Track trackOne = new Track(directions);
                    directions = sr.ReadLine()?.Split(',');
                    Track trackTwo = new Track(directions);
                    if (!trackTwo.CreateTrack() || !trackOne.CreateTrack())
                    {
                        return false;
                    }

                    driverOne = new Driver(trackOne, lunchInterval);
                    driverTwo = new Driver(trackTwo, lunchInterval);

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


    }
}
