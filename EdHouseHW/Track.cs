using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace EdHouseHW
{
    internal class Track
    {
        public List<Point> TrackList { get; }

        public Track(string[] directions)
        {
            TrackList = new List<Point>(){new Point(0,0)};
            CreateTrack(directions);
        }

        public Track(Track track, int firstIndex, int lastIndex)
        {
            if (firstIndex > track.TrackList.Count)
            {
                Program.ErrorMsg("driver finishes work before lunch break");
            }
            this.TrackList = track.TrackList.GetRange(firstIndex, (lastIndex - firstIndex + 1 > track.TrackList.Count ? track.TrackList.Count : lastIndex - firstIndex + 1));
        }

        private void CreateTrack(string[] directions)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                ValidateDirection(directions[i]);
                CreateDirection(directions[i]);
            }
        }

        private void ValidateDirection(string direction)
        {
            if (!char.IsLetter(direction[^1]) ||
                !int.TryParse(direction.Substring(0, direction.Length - 1), out _))
            {
                Program.ErrorMsg("directions incorrect");
            }
        }

        private void CreateDirection(string direction)
        {
            char cardDirection = direction[^1];
            int numDirection = int.Parse(direction.Substring(0, direction.Length - 1));
            Point lastPoint = TrackList.Last();
            switch (cardDirection)
            {
                case 'N':
                    for (int j = 1; j <= numDirection; j++)
                    {
                        TrackList.Add(lastPoint with { Y = lastPoint.Y + j });
                    }
                    break;

                case 'S':
                    for (int j = 1; j <= numDirection; j++)
                    {
                        TrackList.Add(lastPoint with { Y = lastPoint.Y - j });
                    }
                    break;

                case 'E':
                    for (int j = 1; j <= numDirection; j++)
                    {
                        TrackList.Add(lastPoint with { X = lastPoint.X + j });
                    }
                    break;

                case 'W':
                    for (int j = 1; j <= numDirection; j++)
                    {
                        TrackList.Add(lastPoint with { X = lastPoint.X - j });
                    }
                    break;

                default:
                    Program.ErrorMsg("direction incorrect");
                    break;
            }
        }
    }
}
