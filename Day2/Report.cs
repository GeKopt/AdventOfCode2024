﻿using static System.Net.Mime.MediaTypeNames;

namespace Day2
{
    public class Report
    {
        public List<int> levels { get; } = new List<int>();

        public Report(string report)
        {
            var split = report.Split(' ');
            foreach(var level in  split) 
            {
                levels.Add(int.Parse(level));
            }
        }

        public bool IsSafe()
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

        private bool IsWithinRange(int current , int next)
        {
            return Math.Abs(current - next) > 0 && Math.Abs(current - next) < 4;
        }

        private bool IsSwitchingDirection(bool increasing, int current, int next)
        {
            return (increasing && current > next) || (!increasing && current < next);
        }
    }
}