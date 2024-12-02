using Day2;
using FluentAssertions;

namespace AdventOfCode.Tests.Day2
{
    public class ReportTests
    {
        [TestCase("1 3 2 4 5")]
        [TestCase("6 8 11 12 14 16 18 16")]
        public void IsSafe_ShouldReturnFalse_WhenDirectionChanges(string report)
        {
            var sut = new Report(report);
            sut.IsSafe().Should().BeFalse();
        }

        [Test]
        public void IsSafe_ShouldReturnFalse_WhenIncreaseIsMoreThanTwo()
        {
            var sut = new Report("1 2 7 8 9");
            sut.IsSafe().Should().BeFalse();
        }

        [Test]
        public void IsSafe_ShouldReturnFalse_WhenDecreaseIsMoreThanTwo()
        {
            var sut = new Report("9 7 6 2 1");
            sut.IsSafe().Should().BeFalse();
        }

        [TestCase("8 6 4 4 1")]
        [TestCase("73 76 79 80 81 84 86 86")]
        public void IsSafe_ShouldReturnFalse_WhenLevelsStayTheSame(string report)
        {
            var sut = new Report(report);
            sut.IsSafe().Should().BeFalse();
        }

        [Test]
        public void IsSafe_ShouldReturnTrue_WhenAllIncreasingWithinRange()
        {
            var sut = new Report("7 6 4 2 1");
            sut.IsSafe().Should().BeTrue();
        }

        [Test]
        public void IsSafe_ShouldReturnTrue_WhenAllDecreasingWithinRange()
        {
            var sut = new Report("1 3 6 7 9");
            sut.IsSafe().Should().BeTrue();
        }



        [TestCase("1 3 2 4 5")]
        public void IsSafeWithDampener_ShouldReturnTrue_WhenDirectionChangesOnce(string report)
        {
            var sut = new Report(report);
            sut.IsSafeWithDampener().Should().BeTrue();
        }

        [Test]
        public void IsSafeWithDampener_ShouldReturnFalse_WhenIncreaseIsMoreThanTwo()
        {
            var sut = new Report("1 2 7 8 9");
            sut.IsSafeWithDampener().Should().BeFalse();
        }

        [Test]
        public void IsSafeWithDampener_ShouldReturnFalse_WhenDecreaseIsMoreThanTwo()
        {
            var sut = new Report("9 7 6 2 1");
            sut.IsSafeWithDampener().Should().BeFalse();
        }

        [TestCase("8 6 4 4 1")]
        [TestCase("73 76 79 80 81 84 86 86")]
        [TestCase("6 8 11 12 14 16 16")]
        public void IsSafeWithDampener_ShouldReturnTrue_WhenLevelsStayTheSame(string report)
        {
            var sut = new Report(report);
            sut.IsSafeWithDampener().Should().BeTrue();
        }

        [Test]
        public void IsSafeWithDampener_ShouldReturnTrue_WhenAllIncreasingWithinRange()
        {
            var sut = new Report("7 6 4 2 1");
            sut.IsSafeWithDampener().Should().BeTrue();
        }

        [Test]
        public void IsSafeWithDampener_ShouldReturnTrue_WhenAllDecreasingWithinRange()
        {
            var sut = new Report("1 3 6 7 9");
            sut.IsSafeWithDampener().Should().BeTrue();
        }

        [TestCase("32 33 34 37 40 44")]
        public void IsSafeWithDampener_ShouldReturnTrue_WithGivenReport(string report)
        {
            var sut = new Report(report);
            sut.IsSafeWithDampener().Should().BeTrue();
        }

    }
}
