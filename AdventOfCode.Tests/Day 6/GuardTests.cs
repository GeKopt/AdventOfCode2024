using Day6;
using FluentAssertions;
using System.Drawing;

namespace AdventOfCode.Tests.Day_6
{
    public class GuardTests
    {
        [TestCase(Direction.NORTH, 1, 0)]
        [TestCase(Direction.EAST, 2, 1)]
        [TestCase(Direction.SOUTH, 1, 2)]
        [TestCase(Direction.WEST, 0, 1)]
        public void Move_ShouldMoveNorth_WhenDirectionIsNorth(Direction direction, int expectedX, int expectedY)
        {
            var sut = new Guard(new Point(1, 1), direction);
            sut.Move();
            sut.CurrentPosition.Should().Be(new Point(expectedX, expectedY));
        }

        [TestCase(Direction.NORTH, Direction.EAST)]
        [TestCase(Direction.EAST, Direction.SOUTH)]
        [TestCase(Direction.SOUTH, Direction.WEST)]
        [TestCase(Direction.WEST, Direction.NORTH)]
        public void Turn_ShouldSetNewDirectionTo90DecreesRight_WhenCalled(Direction direction, Direction expected)
        {
            var sut = new Guard(new Point(1, 1), direction);
            sut.Turn();
            sut.CurrentDirection.Should().Be(expected);
        }
    }
}
