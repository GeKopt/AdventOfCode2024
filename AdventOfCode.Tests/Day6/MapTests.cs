using Day6;
using FluentAssertions;

namespace AdventOfCode.Tests.Day_6
{
    public class MapTests
    {
        [Test]
        public void GetMappedPositions_ShouldReturnNumberOfRunPositions_WhenCalled()
        {
            var sut = new Map(new List<string>()
            {
                "....#.....",
                "....XXXXX#",
                "....X...X.",
                "..#.X...X.",
                "..XXXXX#X.",
                "..X.X.X.X.",
                ".#XXXXXXX.",
                ".XXXXXXX#.",
                "#XXXXXXX..",
                "......#X.."
            });
            sut.GetMappedPositions().Should().Be(41);
        }
    }
}
