using System.Drawing;

namespace Day4
{
    public class ChristmasFinder
    {
        private WordGrid _grid;

        public ChristmasFinder(WordGrid grid)
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
                    if (_grid.Letters[rowIndex, columnIndex] == 'X')
                    {
                        totalWords += GetMatchesInAllDirections(new Point(rowIndex, columnIndex));
                    }
                }
            }
            return totalWords;
        }

        private int GetMatchesInAllDirections(Point currentPosition)
        {
            var total = 0;
            if (IsNorthWest(currentPosition))
            {
                total++;
            }
            if (IsNorth(currentPosition))
            {
                total++;
            }
            if (IsNorthEast(currentPosition))
            {
                total++;
            }
            if (IsEast(currentPosition))
            {
                total++;
            }
            if (IsSouthEast(currentPosition))
            {
                total++;
            }
            if (IsSouth(currentPosition))
            {
                total++;
            }
            if (IsSouthWest(currentPosition))
            {
                total++;
            }
            if (IsWest(currentPosition))
            {
                total++;
            }
            return total;
        }

        private bool IsNorthWest(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X - 3 < 0 || currentPosition.Y - 3 < 0)
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X - x, currentPosition.Y - x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNorth(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X - 3 < 0)
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X - x, currentPosition.Y] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNorthEast(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X - 3 < 0 || currentPosition.Y + 3 >= _grid.Letters.GetLength(1))
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X - x, currentPosition.Y + x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsEast(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.Y + 3 >= _grid.Letters.GetLength(1))
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X, currentPosition.Y + x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSouthEast(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X + 3 >= _grid.Letters.GetLength(1) || currentPosition.Y + 3 >= _grid.Letters.GetLength(1))
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X + x, currentPosition.Y + x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSouth(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X + 3 >= _grid.Letters.GetLength(1))
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X + x, currentPosition.Y] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSouthWest(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.X + 3 >= _grid.Letters.GetLength(1) || currentPosition.Y - 3 < 0)
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X + x, currentPosition.Y - x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsWest(Point currentPosition)
        {
            var currentChar = 'X';
            if (currentPosition.Y - 3 < 0)
            {
                return false;
            }
            for (int x = 1; x < 4; x++)
            {
                currentChar = GetNextCharacter(currentChar);
                if (_grid.Letters[currentPosition.X, currentPosition.Y - x] != currentChar)
                {
                    return false;
                }
            }
            return true;
        }

        private char GetNextCharacter(char current)
        {
            return current switch
            {
                'X' => 'M',
                'M' => 'A',
                'A' => 'S',
                _ => ' '
            };
        }
    }
}
