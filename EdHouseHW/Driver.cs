using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EdHouseHW
{
    internal class Driver
    {
        enum CardinalDirections
        {
            North = 'N',
            South = 'S',
            East = 'E',
            West = 'W'
        }

        public List<Point> Track { get; private set; } // list of all the points crossed based on the given directions

        public Driver(string[] directions)
        {
            CreateTrack(directions);
        }

        private void CreateTrack(string[] directions) // creates the track based on the given directions
        {
            try
            {
                Track = new List<Point> { new (0, 0) };
                foreach (var direction in directions)
                {
                    int numDirection = ReadNumDirection(direction);
                    char cardDirection = ReadCardDirection(direction);
                    Track.AddRange(LoadPointsInTheDirection(Track.Last(), numDirection, cardDirection));
                }
            }
            catch (Exception)
            {
                throw new InputException("Could not read directions correctly.");
            }
        }

        private List<Point> LoadPointsInTheDirection(Point lastPoint, int numDirection, char cardDirection) // takes last point on the track and generates all points in the new directions
        {
            List<Point> points = new List<Point>();
            switch (cardDirection)
            {
                case (char)CardinalDirections.North:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { Y = lastPoint.Y + j });
                    }
                    break;

                case (char)CardinalDirections.South:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { Y = lastPoint.Y - j });
                    }
                    break;

                case (char)CardinalDirections.East:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { X = lastPoint.X + j });
                    }
                    break;

                case (char)CardinalDirections.West:
                    for (int j = 1; j <= numDirection; j++)
                    {
                        points.Add(lastPoint with { X = lastPoint.X - j });
                    }
                    break;

                default:
                    throw new InputException("Wrong input in cardinal directions."); // if cardinal direction incorrect, exception thrown
            }
            return points;
        }


        private char ReadCardDirection(string direction) // returns last char of the direction as a cardinal direction
        {
            return direction[^1];
        }

        private int ReadNumDirection(string direction) // returns a numerical direction, if the direction is incorrect, exception thrown
        {
            if (direction.Length < 1 || !int.TryParse(direction.Substring(0, direction.Length - 1), out int numDirection) || numDirection < 0)
            {
                throw new InputException("Wrong input in numeric directions.");
            }
            return numDirection;
        }
    }
}
