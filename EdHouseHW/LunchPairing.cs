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
        private string[] lunchInterval;
        private string[] directionOne;
        private string[] directionTwo;
        private Driver driverOne;
        private Driver driverTwo;
        public Point lunchSpot { get; private set; }

        public LunchPairing(string file)
        {
            LoadInput(file);
            PairDrivers();
        }

        public LunchPairing()
        {
            LoadInput();
            PairDrivers();
        }


        private void PairDrivers()
        {
            CreateDrivers();
            ValidateLunchInterval();
            FindLunchSpot();
        }

        private void CreateDrivers()
        {
            driverOne = new Driver(directionOne);
            driverTwo = new Driver(directionTwo);
        }

        private void FindLunchSpot()
        {
            int start = int.Parse(lunchInterval[0]);
            int end = int.Parse(lunchInterval[1]);
            
            try
            {
                for (int point = start; point <= end; point++)
                {
                    if (driverOne.Track[point] == driverTwo.Track[point])
                    {
                        lunchSpot = driverOne.Track[point];
                        return;
                    }
                }
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Could not find a suitable place for the lunch.");
                throw;
            }
        }

        private void ValidateLunchInterval()
        {
            if (lunchInterval.Length != 2 || !int.TryParse(lunchInterval[0], out _) || !int.TryParse(lunchInterval[1], out _))
            {
                throw new InputException("Wrong input in lunch intervals.");
            }
        }

        private void LoadInput(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            {
                lunchInterval = sr.ReadLine()?.Split('-');
                directionOne = sr.ReadLine()?.Split(',');
                directionTwo = sr.ReadLine()?.Split(',');
            }
        }
        private void LoadInput()
        {
            lunchInterval = Console.ReadLine()?.Split('-');
            directionOne = Console.ReadLine()?.Split(',');
            directionTwo = Console.ReadLine()?.Split(',');
        }

    }
}
