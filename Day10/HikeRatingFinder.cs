using System.Drawing;

namespace Day10
{
    public class HikeRatingFinder
    {
        private Map _map;
        private const int END = 9;
        private List<Point> endPointsReached = new List<Point>();

        public HikeRatingFinder(Map map)
        {
            _map = map;
        }

        public int GetRating(Point start)
        {
            GetValidRatingPaths(start);
            return endPointsReached.Count;
        }

        private void GetValidRatingPaths(Point start)
        {
            var possibleNextPaths = _map.GetNextPositions(start);
            if (_map.GetValue(start) + 1 == END)
            {
                foreach (var path in possibleNextPaths)
                {
                    endPointsReached.Add(path);
                }
                return;
            }
            foreach (var position in possibleNextPaths)
            {
                GetValidRatingPaths(position);
            }
        }
    }
}
