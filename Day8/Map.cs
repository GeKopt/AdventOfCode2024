using System.Drawing;

namespace Day8
{
    public class Map
    {
        public GridPosition[,] Positions { get; }
        public const char Antinode = '#';
        public const char Empty = '.';

        public Map(List<string> rows)
        {
            Positions = new GridPosition[rows.First().Length, rows.Count];
            FillGrid(rows);
        }

        public void AddAntinode(Point position)
        {
            if (IsOutOfBounds(position))
            {
                return;
            }
            Positions[position.X, position.Y].IsAntiNode = true;
        }

        public int GetTotalAntinodes()
        {
            var total = 0;
            for (int rowIndex = 0; rowIndex < Positions.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Positions.GetLength(0); columnIndex++)
                {
                    if (Positions[columnIndex, rowIndex].IsAntiNode)
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        public bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.Y < 0 || position.X >= Positions.GetLength(0) || position.Y >= Positions.GetLength(1);
        }

        public List<Point> GetAntennaPositions(char antenna)
        {
            var positions = new List<Point>();
            for (int rowIndex = 0; rowIndex < Positions.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Positions.GetLength(0); columnIndex++)
                {
                    if (Positions[columnIndex, rowIndex].Value == antenna)
                    {
                        positions.Add(new Point(columnIndex, rowIndex));
                    }
                }
            }
            return positions;
        }

        private void FillGrid(List<string> rows)
        {
            for (int rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
            {
                var row = rows[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    Positions[columnIndex, rowIndex] = new GridPosition(row[columnIndex]);
                }
            }
        }
  
        public override string ToString()
        {
            var rows = new List<string>();
            for (int rowIndex = 0; rowIndex < Positions.GetLength(1); rowIndex++)
            {
                var row = "";
                for (int columnIndex = 0; columnIndex < Positions.GetLength(0); columnIndex++)
                {
                    row += Positions[columnIndex, rowIndex].Value;
                }
                rows.Add(row);
            }
            return string.Join(Environment.NewLine, rows);
        }

        public string ShowAntinodes()
        {
            var rows = new List<string>();
            for (int rowIndex = 0; rowIndex < Positions.GetLength(1); rowIndex++)
            {
                var row = "";
                for (int columnIndex = 0; columnIndex < Positions.GetLength(0); columnIndex++)
                {
                    if (!Positions[columnIndex, rowIndex].IsAntiNode)
                    {
                        row += '.';
                    }
                    else
                    {
                        row += '#';
                    }                    
                }
                rows.Add(row);
            }
            return string.Join(Environment.NewLine, rows);
        }
    }
}
