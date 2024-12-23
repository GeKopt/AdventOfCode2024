﻿namespace Day10
{
    public class Hikes
    {
        private Map _map;

        public Hikes(Map map)
        {
            _map = map;
        }

        public int GetTotalHikes()
        {
            var total = 0;
            var trailHeads = _map.GetTrailHeads();
            foreach (var trail in trailHeads)
            {
                var finder = new HikePathFinder(_map);
                total += finder.GetPossibleHikePaths(trail);
            }
            return total;
        }

        public int GetTotalRating()
        {
            var total = 0;
            var trailHeads = _map.GetTrailHeads();
            foreach (var trail in trailHeads)
            {
                var finder = new HikeRatingFinder(_map);
                total += finder.GetRating(trail);
            }
            return total;
        }
    }
}
