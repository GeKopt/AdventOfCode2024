using System.Drawing;

namespace Day6
{
    public class GuardNavigator
    {
        private Map _map;
        private Guard _guard = new Guard(new Point(0, 0), Direction.NORTH);

        public GuardNavigator(Map map)
        {
            _map = map;
            SetInitialPosition();
        }

        public GuardNavigator(Map map, Guard guard)
        {
            _map = map;
            _guard = guard;
        }

        private void SetInitialPosition()
        {
            for (int x = 0; x < _map.Positions.GetLength(0); x++)
            {
                for (int y = 0; y < _map.Positions.GetLength(1); y++)
                {
                    if (_map.Positions[x, y] == '^')
                    {
                        _guard = new Guard(new Point(x, y), Direction.NORTH);
                        _map.Positions[_guard.CurrentPosition.X, _guard.CurrentPosition.Y] = 'X';
                        return;
                    }
                }
            }
        }

        public Map Navigate()
        {
            _guard.Move();
            _map.Positions[_guard.CurrentPosition.X, _guard.CurrentPosition.Y] = 'X';
            while (true)
            {
                var nextPosition = _guard.GetNextPosition();
                if (_map.IsOutOfBounds(nextPosition))
                {
                    break;
                }
                if (_map.IsBlocked(nextPosition))
                {
                    _guard.Turn();
                }
                _guard.Move();
                _map.Positions[_guard.CurrentPosition.X, _guard.CurrentPosition.Y] = 'X';
            }
            return _map;
        }

        public bool HasLoop()
        {
            var route = new List<Point>();
            while (true)
            {
                var nextPosition = _guard.GetNextPosition();
                if (_map.IsOutOfBounds(nextPosition))
                {
                    break;
                }
                if (_map.IsBlocked(nextPosition) || _map.IsLoopBlocked(nextPosition))
                {
                    _guard.Turn();
                    continue;
                }

                _guard.Move();
                route.Add(_guard.CurrentPosition);
                _map.Positions[_guard.CurrentPosition.X, _guard.CurrentPosition.Y] = 'X';
                if (IsLooping(route, _guard.CurrentPosition, _guard.GetNextPosition()))
                {
                    Console.WriteLine(_map.ToString());
                    Console.WriteLine(Environment.NewLine);
                    return true;
                }
            }
            return false;
        }

        private bool IsLooping(List<Point> route, Point currentPosition, Point nextPosition)
        {
            if (!route.Contains(currentPosition) || !route.Contains(nextPosition))
            {
                return false;
            }

            var nextPositionIndex = route.IndexOf(currentPosition) + 1;
            if (nextPositionIndex < route.Count)
            {
                return route[nextPositionIndex] == nextPosition;
            }
            return false;
        }
    }
}
