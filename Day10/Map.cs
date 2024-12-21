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

        public Map Clone()
        {
            var clonedPositions = new int[Positions.GetLength(0), Positions.GetLength(1)];
            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    clonedPositions[x, y] = Positions[x, y];
                }
            }
            return new Map(clonedPositions);
        }
    }
}
