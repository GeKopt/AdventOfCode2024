using System.Drawing;

namespace Day4
{
    public class MasFinder
    {
        private WordGrid _grid;

        public MasFinder(WordGrid grid)
        {
            _grid = grid;
        }

        public int FindOccurances()
        {
            var totalWords = 0;
            for (int rowIndex = 0; rowIndex < _grid.Letters.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _grid.Letters.GetLength(1); columnIndex++)
                {
                    if (_grid.Letters[rowIndex, columnIndex] == 'A')
                    {
                        var currentPosition = new Point(rowIndex, columnIndex);
                        if (!IsWithinBounds(currentPosition))
                        {
                            continue;
                        }
                        if (IsEastWest(currentPosition) && IsWestEast(currentPosition))
                        {
                            totalWords++;
                        }
                    }
                }
            }
            return totalWords;
        }

        private bool IsWithinBounds(Point currentPosition)
        {
            return currentPosition.X - 1 >= 0 && currentPosition.X + 1 < _grid.Letters.GetLength(0) && currentPosition.Y - 1 >= 0 && currentPosition.Y + 1 < _grid.Letters.GetLength(1);
        }

        private bool IsEastWest(Point currentPosition)
        {
            return _grid.Letters[currentPosition.X - 1, currentPosition.Y - 1] == 'M' && _grid.Letters[currentPosition.X + 1, currentPosition.Y + 1] == 'S' ||
                _grid.Letters[currentPosition.X - 1, currentPosition.Y - 1] == 'S' && _grid.Letters[currentPosition.X + 1, currentPosition.Y + 1] == 'M';
        }

        private bool IsWestEast(Point currentPosition)
        {
            return _grid.Letters[currentPosition.X + 1, currentPosition.Y - 1] == 'M' && _grid.Letters[currentPosition.X - 1, currentPosition.Y + 1] == 'S' ||
                _grid.Letters[currentPosition.X + 1, currentPosition.Y - 1] == 'S' && _grid.Letters[currentPosition.X - 1, currentPosition.Y + 1] == 'M';
        }
    }
}
