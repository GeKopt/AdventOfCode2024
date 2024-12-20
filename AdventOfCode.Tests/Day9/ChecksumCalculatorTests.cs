using Day9;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day9
{
    public class ChecksumCalculatorTests
    {
        [Test]
        public void Calculate_ShouldCalculateCorrectChecksum_WhenCalledWithOrderByFragmentation()
        {
            var files = new List<FileBlock>()
            {
                new FileBlock(0),
                new FileBlock(0),
                new FileBlock(9),
                new FileBlock(9),
                new FileBlock(8),
                new FileBlock(1),
                new FileBlock(1),
                new FileBlock(1),
                new FileBlock(8),
                new FileBlock(8),
                new FileBlock(8),
                new FileBlock(2),
                new FileBlock(7),
                new FileBlock(7),
                new FileBlock(7),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(6),
                new FileBlock(4),
                new FileBlock(4),
                new FileBlock(6),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(6),
                new FileBlock(6)
            };
            var sut = new ChecksumCalculator(files);
            sut.Calculate().Should().Be(1928);
        }

        [Test]
        public void Calculate_ShouldCalculateCorrectChecksum_WhenCalledWithOrderByBlock()
        {
            var files = new List<FileBlock>()
            {
                new FileBlock(0),
                new FileBlock(0),
                new FileBlock(9),
                new FileBlock(9),
                new FileBlock(2),
                new FileBlock(1),
                new FileBlock(1),
                new FileBlock(1),
                new FileBlock(7),
                new FileBlock(7),
                new FileBlock(7),
                new FileBlock(-1),
                new FileBlock(4),
                new FileBlock(4),
                new FileBlock(-1),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(5),
                new FileBlock(-1),
                new FileBlock(6),
                new FileBlock(6),
                new FileBlock(6),
                new FileBlock(6),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(8),
                new FileBlock(8),
                new FileBlock(8),
                new FileBlock(8),
                new FileBlock(-1),
                new FileBlock(-1)
            };
            var sut = new ChecksumCalculator(files);
            sut.Calculate().Should().Be(2858);
        }

        [Test]
        public void Calculate_ShouldCalculateCorrectChecksum_WhenCalledWithOrderByBlock2()
        {
            var files = new List<FileBlock>()
            {
                new FileBlock(0),
                new FileBlock(2),
                new FileBlock(1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(3),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1),
                new FileBlock(-1)
            };
            var sut = new ChecksumCalculator(files);
            sut.Calculate().Should().Be(169);
        }
    }
}
