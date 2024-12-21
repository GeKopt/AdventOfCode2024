using System.Drawing;

namespace Day10
{
    public class Path
    {
        public Point Start { get; }
        public Point End { get; }

        public Path(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            var current = (Path)obj;
            return current.Start == Start && current.End == End;
        }
    }
}
