using Day8;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day8
{
    internal class MapTests
    {
        [Test]
        public void AddAntinode_ShouldAddAntinode_WhenPositionIsFree()
        {
            var sut = new Map(new List<string>()
            {
                "...."
            });

            sut.AddAntinode(new Point(1, 0));
            sut.Positions[1, 0].Value.Should().Be('#');
        }

        [Test]
        public void AddAntinode_ShouldNotAddAntinode_WhenPositionIsAntenna()
        {
            var sut = new Map(new List<string>()
            {
                ".A.."
            });

            sut.AddAntinode(new Point(1, 0));
            sut.Positions[1, 0].Value.Should().Be('A');
        }

        [Test]
        public void GetTotalAntinodes_ShouldReturnCorrectNumberOfAntinodes_WhenMapHasAntinodes()
        {
            var sut = new Map(new List<string>()
            {
                "#...",
                "....",
                "..#."
            });

            sut.GetTotalAntinodes().Should().Be(2);
        }

        [Test]
        public void GetAntennaPositions_ShouldReturnCorrectPositions_WhenMapHasAntennas()
        {
            var sut = new Map(new List<string>()
            {
                "....",
                ".A.A",
                "...."
            });

            var positions = sut.GetAntennaPositions('A');
            var expected = new List<Point> { new Point(1, 1), new Point(3, 1) };
            positions.Should().Equal(expected);
        }
    }
}
