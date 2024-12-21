using Day9;
using FluentAssertions;

namespace AdventOfCode.Tests.Day9
{
    internal class IntegrationTests
    {
        [TestCase("43623251202", 636)]
        [TestCase("1124212", 58)]
        public void Checksum_ShouldBeCorrect_WhenFileIsGiven(string file, int checksum)
        {
            var fileSystem = new FileSystem(file);
            var orderer = new FileOrderer(fileSystem.Files);
            var calculator = new ChecksumCalculator(orderer.OrderByBlock());
            calculator.Calculate().Should().Be(checksum);
        }

        [TestCase("2433133121414131402", "0099441117772333.......5555.6666.....8888..")]
        public void Order_ShouldBeCorrect_WhenFileIsGiven(string file, string expected)
        {
            var fileSystem = new FileSystem(file);
            var orderer = new FileOrderer(fileSystem.Files);
            var orderedFiles = orderer.OrderByBlock();
            FilePresenter.GetString(orderedFiles).Should().Be(expected);
        }
    }
}
