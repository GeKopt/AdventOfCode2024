using System.Drawing;

namespace Day10
{
    public class Map
    {
        public int[,] Positions { get; }
        public const int OUTOFBOUNDS = -1;

        public Map(List<string> rows)
        {
            Positions = new int[rows.First().Length, rows.Count];
            FillGrid(rows);
        }

        public Map(int[,] positions)
        {
            Positions = positions;
        }

        public List<Point> GetTrailHeads()
        {
            var trailHeaders = new List<Point>();
            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    if (Positions[x, y] == 0)
                    {
                        trailHeaders.Add(new Point(x, y));
                    }
                }
            }
            return trailHeaders;
        }

        private void FillGrid(List<string> rows)
        {
            for (int rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
            {
                var row = rows[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    Positions[columnIndex, rowIndex] = int.Parse(row[columnIndex].ToString());
                }
            }
        }

        public bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.Y < 0 || position.X >= Positions.GetLength(0) || position.Y >= Positions.GetLength(1);
        }

        public override string ToString()
        {
            var rows = new List<string>();
            for (int rowIndex = 0; rowIndex < Positions.GetLength(1); rowIndex++)
            {
                var row = "";
                for (int columnIndex = 0; columnIndex < Positions.GetLength(0); columnIndex++)
                {
                    row += Positions[columnIndex, rowIndex];
                }
                rows.Add(row);
            }
            return string.Join(Environment.NewLine, rows);
        }

        public int GetValue(Point position)
        {
            if (!IsOutOfBounds(position))
            {
                return Positions[position.X, position.Y];
            }
            return OUTOFBOUNDS;
        }

        public IEnumerable<Point> GetNextPositions(Point start)
        {
            var currentValue = GetValue(start);

            var possiblePositions = new List<Point>()
            {
                GetNextPoint(Direction.NORTH, start),
                GetNextPoint(Direction.EAST, start),
                GetNextPoint(Direction.SOUTH, start),
                GetNextPoint(Direction.WEST, start),
            };
            foreach (var position in possiblePositions)
            {
                if (GetValue(position) == currentValue + 1)
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
                Direction.EAST => new Point(current.X + 1, current.Y),
                Direction.SOUTH => new Point(current.X, current.Y + 1),
                Direction.WEST => new Point(current.X - 1, current.Y),
                _ => throw new InvalidOperationException("Direction not supported")
            };
        }
    }
}
