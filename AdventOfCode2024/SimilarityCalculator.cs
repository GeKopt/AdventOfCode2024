namespace Day1
{
    public class SimilarityCalculator
    {
        private Locations _locations;
        private List<int> _toMatch = new List<int>();
        private Dictionary<int, int> _grouped = new Dictionary<int, int>();

        public SimilarityCalculator(Locations locations)
        {
            _locations = locations;
            _toMatch = _locations.Right;
            var grouped = _toMatch.GroupBy(current => current, (key, items) => new { Key = key, Count = items.Count() });
            foreach (var group in grouped)
            {
                _grouped.Add(group.Key, group.Count);
            }
        }

        public int CalculateSimilatiryScore(int toCheck)
        {
            if (!_grouped.ContainsKey(toCheck))
            {
                return 0;
            }

            return toCheck * _grouped[toCheck];
        }

        public int CalculateTotalSimilarityScore()
        {
            int total = 0;
            foreach (var current in _locations.Left)
            {
                total += CalculateSimilatiryScore(current);
            }
            return total;
        }
    }
}
