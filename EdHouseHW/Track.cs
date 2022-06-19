using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace EdHouseHW
{
    enum CardinalSides
    {
        N = 'N',
        S = 'S',
        E = 'E',
        W = 'W'
    }

    internal class Track
    {
        private List<Point> trackList;
        private string[] directionsOne;

        public Track(string[] directionsOne)
        {
            this.directionsOne = directionsOne;
        }
    }
}
