using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class HikePathFinder
    {
        private Map _map;
        private const int END = 9;
        private List<Point> endPointsReached = new List<Point>();

        public HikePathFinder(Map map)
        {
            _map = map;
        }

        public int GetPossibleHikePaths(Point start)
        {
            GetValidPaths(start);
            return endPointsReached.Count;
        }

        private void GetValidPaths(Point start) 
        {
            var possibleNextPaths = GetNextPositions(start);
            if (_map.GetValue(start) + 1 == END)
            {
                foreach(var path in possibleNextPaths)
                {
                    if (!endPointsReached.Contains(path))
                    {
                        endPointsReached.Add(path);
                    }
                }
                return;
            }
            foreach(var position in possibleNextPaths)
            {
                GetValidPaths(position);
            }
        }

        private IEnumerable<Point> GetNextPositions(Point start)
        {
            var currentValue = _map.GetValue(start);

            var possiblePositions = new List<Point>()
            {
                GetNextPoint(Direction.NORTH, start),
                //GetNextPoint(Direction.NORTHEAST, start),
                GetNextPoint(Direction.EAST, start),
                //GetNextPoint(Direction.SOUTHEAST, start),
                GetNextPoint(Direction.SOUTH, start),
                //GetNextPoint(Direction.SOUTHWEST, start),
                GetNextPoint(Direction.WEST, start),
                //GetNextPoint(Direction.NORTHWEST, start)
            };
            foreach (var position in possiblePositions)
            {
                if (_map.GetValue(position) == currentValue + 1)
                {
                    yield return position;
                }
            }
        }

        private Point GetNextPoint(Direction direction, Point current)
        {
            return direction switch
            {
                Direction.NORTH => new Point(current.X, current.Y - 1),
                Direction.NORTHEAST => new Point(current.X + 1, current.Y - 1),
                Direction.EAST => new Point(current.X + 1, current.Y),
                Direction.SOUTHEAST => new Point(current.X + 1, current.Y + 1),
                Direction.SOUTH => new Point(current.X, current.Y + 1),
                Direction.SOUTHWEST => new Point(current.X - 1, current.Y + 1),
                Direction.WEST => new Point(current.X - 1, current.Y),
                Direction.NORTHWEST => new Point(current.X - 1, current.Y - 1),
                _ => throw new InvalidOperationException("Direction not supported")
            };
        }
    }
}
