using Day11;
using FluentAssertions;

namespace AdventOfCode.Tests.Day11
{
    internal class BlinkerTests
    {
        [TestCase(new long[] { 125, 17 }, 3)]
        [TestCase(new long[] { 253000, 1, 7 }, 4)]
        [TestCase(new long[] { 253, 0, 2024, 14168 }, 5)]
        [TestCase(new long[] { 512072, 1, 20, 24, 28676032 }, 9)]
        [TestCase(new long[] { 512, 72, 2024, 2, 0, 2, 4, 2867, 6032 }, 13)]
        [TestCase(new long[] { 1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32 }, 22)]
        public void Stones_ShouldBeCorrectAmount_WhenBlinking(long[] numbers, int expected)
        {
            var sut = new Blinker(numbers.ToList());
            sut.Blink().Should().Be(expected);
        }

        [TestCase(1, 3 )]
        [TestCase(2, 4)]
        [TestCase(3, 5)]
        [TestCase(4, 9)]
        [TestCase(5, 13)]
        [TestCase(6, 22)]
        [TestCase(25, 55312)]
        public void Stones_ShouldBeCorrectAmount_WhenBlinkingMultipleTimes(int blinks, long expected)
        {
            var stones = new List<long>() { 125, 17 };
            var sut = new Blinker(stones);
            sut.Blink(blinks).Should().Be(expected);
        }

    }
}
