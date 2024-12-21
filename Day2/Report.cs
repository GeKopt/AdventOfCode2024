namespace Day2
{
    public class Report
    {
        public List<int> Levels { get; } = new List<int>();

        public Report(string report)
        {
            var split = report.Split(' ');
            foreach (var level in split)
            {
                Levels.Add(int.Parse(level));
            }
        }

        public bool IsSafeWithDampener()
        {
            if (IsSafe(Levels))
            {
                return true;
            }

            for (int index = 0; index < Levels.Count; index++)
            {
                var dampenedLevels = Levels.ToList();
                dampenedLevels.RemoveAt(index);
                if (IsSafe(dampenedLevels))
                {
                    return true;
                }
            }
            return false;

        }

        public bool IsSafe()
        {
            return IsSafe(Levels);
        }

        public bool IsSafe(List<int> levels)
        {
            bool increasing = levels[0] < levels[1];
            for (int index = 0; index < levels.Count - 1; index++)
            {
                var current = levels[index];
                var next = levels[index + 1];

                if (IsSwitchingDirection(increasing, current, next))
                {
                    return false;
                }


                if (!IsWithinRange(current, next))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsWithinRange(int current, int next)
        {
            return Math.Abs(current - next) > 0 && Math.Abs(current - next) < 4;
        }

        private bool IsSwitchingDirection(bool increasing, int current, int next)
        {
            return (increasing && current > next) || (!increasing && current < next);
        }
    }
}
