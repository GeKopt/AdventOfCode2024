using System.Drawing;

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
            var possibleNextPaths = _map.GetNextPositions(start);
            if (_map.GetValue(start) + 1 == END)
            {
                foreach (var path in possibleNextPaths)
                {
                    if (!endPointsReached.Contains(path))
                    {
                        endPointsReached.Add(path);
                    }
                }
                return;
            }
            foreach (var position in possibleNextPaths)
            {
                GetValidPaths(position);
            }
        }
    }
}
