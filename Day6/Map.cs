using System.Drawing;

namespace Day6
{
    public class Map
    {
        public char[,] Positions { get; }
        public bool HasLoopBlock = false;

        public Map(List<string> rows)
        {
            Positions = new char[rows.First().Length, rows.Count];
            FillGrid(rows);
        }

        public Map(char[,] positions)
        {
            Positions = positions;
        }

        private void FillGrid(List<string> rows)
        {
            for (int rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
            {
                var row = rows[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    Positions[columnIndex, rowIndex] = row[columnIndex];
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

        public bool IsAlreadyVisited(Point position)
        {
            return Positions[position.X, position.Y] == 'X';
        }

        public bool IsBlocked(Point position)
        {
            return Positions[position.X, position.Y] == '#';
        }

        public bool IsLoopBlocked(Point position)
        {
            return Positions[position.X, position.Y] == 'O';
        }

        public int GetMappedPositions()
        {
            var total = 0;
            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    if (Positions[x, y] == 'X')
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        public void AddBlock(Point position)
        {
            Positions[position.X, position.Y] = 'O';
            HasLoopBlock = true;
        }

        public void AddVisited(Point position)
        {
            Positions[position.X, position.Y] = 'X';
        }

        public bool IsPathToBlockVisited(Guard guard)
        {
            var clone = guard.Clone();
            clone.Turn();
            clone.Move();
            while (true)
            {
                var nextPosition = clone.GetNextPosition();
                if (IsOutOfBounds(nextPosition))
                {
                    return false;
                }
                if (IsBlocked(nextPosition))
                {
                    return true;
                }
                clone.Move();
            }
        }

        public Map Clone()
        {
            var clonedPositions = new char[Positions.GetLength(0), Positions.GetLength(1)];
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
