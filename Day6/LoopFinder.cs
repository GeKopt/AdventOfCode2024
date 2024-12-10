using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class LoopFinder
    {
        private Map _startingMap;
        private Guard _initialGuard = new Guard(new Point(0, 0), Direction.NORTH);

        public LoopFinder(Map map)
        {
            _startingMap = map;
            SetInitialPosition();
        }

        private void SetInitialPosition()
        {
            for (int x = 0; x < _startingMap.Positions.GetLength(0); x++)
            {
                for (int y = 0; y < _startingMap.Positions.GetLength(1); y++)
                {
                    if (_startingMap.Positions[x, y] == '^')
                    {
                        _initialGuard = new Guard(new Point(x, y), Direction.NORTH);
                        _startingMap.Positions[_initialGuard.CurrentPosition.X, _initialGuard.CurrentPosition.Y] = 'X';
                        return;
                    }
                }
            }
        }

        public int FindLoops()
        {
            _initialGuard.Move();
            _startingMap.Positions[_initialGuard.CurrentPosition.X, _initialGuard.CurrentPosition.Y] = 'X';

            var setBlocks = new HashSet<Point>();
            var map = _startingMap.Clone();
            var guard = _initialGuard.Clone();
            while (true)
            {
                var nextPosition = guard.GetNextPosition();
                if (map.IsOutOfBounds(nextPosition))
                {
                    break;
                }
                if (map.IsBlocked(nextPosition))
                {
                    guard.Turn();
                }

                guard.Move();
                map.AddVisited(guard.CurrentPosition);
                nextPosition = guard.GetNextPosition();

                if (nextPosition == guard.StartingPosition || map.IsOutOfBounds(nextPosition) || setBlocks.Contains(nextPosition))
                {
                    continue;
                }

                var testmap = _startingMap.Clone();
                testmap.AddBlock(nextPosition);
                var navigator = new GuardNavigator(testmap, _initialGuard.Clone());
                if (navigator.HasLoop())
                {
                    setBlocks.Add(nextPosition);
                }
            }
            return setBlocks.Count;
        }

    }
}
