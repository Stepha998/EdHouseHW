using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouseHW
{
    internal class Driver
    {
        enum CardinalDirections
        {
            N = 'N',
            S = 'S',
            E = 'E',
            W = 'W'
        }

        public List<Point> Track { get; private set; }

        public Driver(string[] directions)
        {
            CreateTrack(directions);
        }

        private void CreateTrack(string[] directions)
        {
            Track = new List<Point> {new Point(0, 0)};
            foreach (var direction in directions)
            {
                int numDirection = ReadNumDirection(direction);
                char cardDirection = ReadCardDirection(direction);
                Track.AddRange(LoadPointsInTheDirection(Track.Last(), numDirection, cardDirection));
            }
        }

        private List<Point> LoadPointsInTheDirection(Point lastPoint, int numDirection, char cardDirection)
        {
            List<Point> points = new List<Point>();
            switch (cardDirection)
            {
                case (char)CardinalDirections.N:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { Y = lastPoint.Y + j });
                    }
                    break;

                case (char)CardinalDirections.S:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { Y = lastPoint.Y - j });
                    }
                    break;

                case (char)CardinalDirections.E:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { X = lastPoint.X + j });
                    }
                    break;

                case (char)CardinalDirections.W:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { X = lastPoint.X - j });
                    }
                    break;

                default:
                    throw new InputException("Wrong input in cardinal directions.");
            }
            return points;
        }


        private char ReadCardDirection(string direction)
        {
            return direction[^1];
        }

        private int ReadNumDirection(string direction)
        {
            if (direction.Length < 1 || !int.TryParse(direction.Substring(0, direction.Length - 1), out int numDirection) || numDirection < 0)
            {
                throw new InputException("Wrong input in numeric directions.");
            }
            return numDirection;
        }
    }
}
