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
        private string[] directionsOne;
        private string[] directionsTwo;
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
            driverOne = new Driver(directionsOne);
            driverTwo = new Driver(directionsTwo);
        }

        private void FindLunchSpot()
        {
            int start = int.Parse(lunchInterval[0]);
            int end = int.Parse(lunchInterval[1]);

            try
            {
                for (int point = start; point < end; point++)
                {
                    if (driverOne.Track[point] == driverTwo.Track[point])
                    {
                        lunchSpot = driverOne.Track[point];
                    }
                }
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
                throw new Exception();
            }
        }

        private void LoadInput(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            {
                lunchInterval = sr.ReadLine()?.Split('-');
                directionsOne = sr.ReadLine()?.Split(',');
                directionsTwo = sr.ReadLine()?.Split(',');
            }
        }
        private void LoadInput()
        {
            lunchInterval = Console.ReadLine()?.Split('-');
            directionsOne = Console.ReadLine()?.Split(',');
            directionsTwo = Console.ReadLine()?.Split(',');
        }

    }
}
