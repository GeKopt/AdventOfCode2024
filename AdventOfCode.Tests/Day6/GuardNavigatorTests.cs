using Day6;
using FluentAssertions;
using System.Drawing;

namespace AdventOfCode.Tests.Day_6
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class GuardNavigatorTests
    {
        private Map _map = new Map(new List<string>()
        {
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#..."
        });

        [Test]
        public void Navigate_ShouldReturnNavigatedMap_WhenCalled()
        {
            var expectedMap = new Map(new List<string>()
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

            var sut = new GuardNavigator(_map);
            var navigatedMap = sut.Navigate();
            navigatedMap.Positions.Should().BeEquivalentTo(expectedMap.Positions);
        }


        [Test]
        public void HasLoop_ShouldBeTrue_WhenTurningInPlace()
        {
            var map = new Map(new List<string>()
            {
                ".#.",
                ".^O",
                "..#",
                "..#",
                "..#",
                "..#",
                "..#",
                "#..",
                ".#.",
            });
            var sut = new GuardNavigator(map);
            sut.HasLoop().Should().BeTrue();

        }
    }
}
