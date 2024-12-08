using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Guard
    {
        public Point StartingPosition { get; private set; }
        public Point CurrentPosition { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public Guard(Point startingPosition, Direction initialDirection)
        {
            CurrentDirection = initialDirection;
            StartingPosition = startingPosition;
            CurrentPosition = startingPosition;
        }

        public Guard(Point startingPosition, Direction initialDirection, Point currentPosition)
        {
            CurrentDirection = initialDirection;
            StartingPosition = startingPosition;
            CurrentPosition = currentPosition;
        }

        public void Move()
        {
            CurrentPosition = GetNextPosition();
        }

        public Point GetNextPosition(Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => new Point(CurrentPosition.X, CurrentPosition.Y - 1),
                Direction.EAST => new Point(CurrentPosition.X + 1, CurrentPosition.Y),
                Direction.SOUTH => new Point(CurrentPosition.X, CurrentPosition.Y + 1),
                Direction.WEST => new Point(CurrentPosition.X - 1, CurrentPosition.Y),
                _ => throw new NotSupportedException()
            };
        }

        public Point GetNextPosition()
        {
            return GetNextPosition(CurrentDirection);
        }

        public Point GetNextTurnedPosition()
        {
            var turnedDirection = GetTurnDirection();
            return GetNextPosition(turnedDirection);
        }

        public void Turn()
        {
            CurrentDirection = GetTurnDirection();
        }

        private Direction GetTurnDirection()
        {
            return CurrentDirection switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => throw new NotSupportedException()
            };
        }

        public Guard Clone()
        {
            return new Guard(StartingPosition, CurrentDirection, CurrentPosition);
        }
    }
}
