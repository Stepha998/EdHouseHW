using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace EdHouseHW
{
    public class LunchPairing
    {
        private string[] lunchInterval;
        private string[] directionOne;
        private string[] directionTwo;
        private Driver driverOne;
        private Driver driverTwo;
        public Point lunchSpot { get; private set; }

        public LunchPairing(string file) // constructor with input from file
        {
            LoadInput(file);
            PairDrivers();
        }

        public LunchPairing() // constructor with input from stdin
        {
            LoadInput();
            PairDrivers();
        }


        private void PairDrivers() // creates drivers based on directions from input and tries to find lunch coordinates
        {
            CreateDrivers();
            FindLunchSpot();
        }

        private void CreateDrivers()
        {
            driverOne = new Driver(directionOne);
            driverTwo = new Driver(directionTwo);
        }

        private void FindLunchSpot() // tries to find lunch coordinates, if no correct coordinate found, exception thrown
        {
            ValidateLunchInterval();
            int start = int.Parse(lunchInterval[0]);
            int end = int.Parse(lunchInterval[1]);
            
            try
            {
                for (int point = start; point <= end; point++)
                {
                    if (driverOne.Track[point] == driverTwo.Track[point]) // if crossing of the tracks of the drivers found, assign lunchSpot to that point and return
                    {
                        lunchSpot = driverOne.Track[point];
                        return;
                    }
                }
                throw new Exception();
            }
            catch (Exception)
            {
                throw new NoPlaceForLunchFoundException("Could not find a suitable place for the lunch.");
            }
        }

        private void ValidateLunchInterval() // checks if given lunch interval from input are 2 numbers, if not, exception thrown
        {
            if (lunchInterval.Length != 2 || !int.TryParse(lunchInterval[0], out _) || !int.TryParse(lunchInterval[1], out _))
            {
                throw new InputException("Wrong input in lunch intervals.");
            }
        }

        private void LoadInput(string file) // loads input from file
        {
            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            {
                lunchInterval = sr.ReadLine()?.Split('-');
                directionOne = sr.ReadLine()?.Split(',');
                directionTwo = sr.ReadLine()?.Split(',');
            }
        }
        private void LoadInput() // loads input from stdin
        {
            lunchInterval = Console.ReadLine()?.Split('-');
            directionOne = Console.ReadLine()?.Split(',');
            directionTwo = Console.ReadLine()?.Split(',');
        }

    }
}
