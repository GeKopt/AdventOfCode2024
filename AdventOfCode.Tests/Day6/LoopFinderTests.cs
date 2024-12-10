using Day6;
using FluentAssertions;

namespace AdventOfCode.Tests.Day_6
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class LoopFinderTests
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
            var sut = new LoopFinder(_map);
            var possibleLoops = sut.FindLoops();
            possibleLoops.Should().Be(6);
        }

        [Test]
        public void HasLoop_ShouldBeTrue_WhenTurningInPlace()
        {
            var map = new Map(new List<string>()
            {
                ".#.",
                "..O",
                "..#",
                "..#",
                "..#",
                "..#",
                "..#",
                "#..",
                ".#.",
            });
            var sut = new LoopFinder(map);
            

        }
    }
}
