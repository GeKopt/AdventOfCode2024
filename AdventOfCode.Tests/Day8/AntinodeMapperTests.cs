using Day8;
using FluentAssertions;
using System.Collections;
using System.Drawing;

namespace AdventOfCode.Tests.Day8
{
    internal class AntinodeMapperTests
    {
        public static IEnumerable PossibleOptions
        {
            get
            {
                yield return new TestCaseData(new Point(2, 2), new Point(4, 2), new List<Point>() { new Point(0, 2), new Point(6, 2) });
                yield return new TestCaseData(new Point(2, 2), new Point(4, 3), new List<Point>() { new Point(0, 1), new Point(6, 4) });
                yield return new TestCaseData(new Point(3, 3), new Point(2, 4), new List<Point>() { new Point(1, 5), new Point(4, 2) });
                yield return new TestCaseData(new Point(4, 2), new Point(2, 4), new List<Point>() { new Point(6, 0), new Point(0, 6) });
            }
        }

        [TestCaseSource(nameof(PossibleOptions))]
        public void GetAntinodePositions_ShouldReturnCorrectPoints_WhenTwoAntennasAreSet(Point start, Point end, List<Point> expected)
        {
            var sut = new AntinodeMapper(null, false);
            sut.GetAntinodePositions(start, end).Should().BeEquivalentTo(expected);
        }

        [Test]
        public void MapAntinodes_ShouldMapAllAntinodes_WhenMapContainsAntennas()
        {
            var map = new Map(new List<string>()
            {
                "..........",
                "..........",
                "..........",
                "....a.....",
                "..........",
                ".....a....",
                "..........",
                "..........",
                "..........",
                ".........."
            }
            );

            var sut = new AntinodeMapper(map, false);
            sut.MapAntinodes();
            map.Positions[3, 1].Value.Should().Be('#');
            map.Positions[6, 7].Value.Should().Be('#');
        }

        [Test]
        public void MapAntinodes_ShouldMapAllAntinodes_WhenMapHasOverlappingAntiNodesAndAntennas()
        {
            var map = new Map(new List<string>()
            {
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............"
            }
            );

            var sut = new AntinodeMapper(map, false);
            sut.MapAntinodes();
            Console.WriteLine(map.ToString());
            Console.WriteLine("");
            Console.WriteLine(map.ShowAntinodes());
            map.GetTotalAntinodes().Should().Be(14);
        }

        [Test]
        public void MapAntinodes_ShouldMapAllAntinodesTillBounds_WhenMapHasAntennas()
        {
            var map = new Map(new List<string>()
            {
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............"
            }
            );

            var sut = new AntinodeMapper(map, true);
            sut.MapAntinodes();
            Console.WriteLine(map.ToString());
            Console.WriteLine("");
            Console.WriteLine(map.ShowAntinodes());
            map.GetTotalAntinodes().Should().Be(34);
        }
    }
}
