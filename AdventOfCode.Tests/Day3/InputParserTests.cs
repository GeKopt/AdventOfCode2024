using Day3;
using FluentAssertions;

namespace AdventOfCode.Tests.Day3
{
    public class InputParserTests
    {
        [Test]
        public void Parse_ShouldReturnMuls_WhenInputIsGiven()
        {
            var input = new List<string>() { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" };

            var expected = new List<long>() { 8,25, 88, 40 };

            var sut = new InputParser(input);
            var parsed = sut.Parse(false);
            parsed.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Parse_ShouldReturnMuls_WhenInputIsGivenWithEnabledState()
        {
            var input = new List<string>() { "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))" };

            var expected = new List<long>() { 8, 40 };

            var sut = new InputParser(input);
            var parsed = sut.Parse(true);
            parsed.Should().BeEquivalentTo(expected);
        }
    }
}
