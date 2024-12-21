namespace Day1
{
    public class DistanceCalculator
    {
        public int CalculateDistance(int left, int right)
        {
            return Math.Max(left, right) - Math.Min(left, right);
        }

        public int CalculateTotalDistance(Locations locations)
        {
            var left = locations.Left.ToList();
            var right = locations.Right.ToList();

            left.Sort();
            right.Sort();
            int total = 0;
            for (int index = 0; index < left.Count; index++)
            {
                var currentLeft = left[index];
                var currentRight = right[index];
                total += CalculateDistance(currentLeft, currentRight);
            }
            return total;
        }
    }
}
