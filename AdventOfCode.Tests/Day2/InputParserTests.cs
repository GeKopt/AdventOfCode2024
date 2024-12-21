using Day2;
using FluentAssertions;

namespace AdventOfCode.Tests.Day2
{
    public class InputParserTests
    {
        [Test]
        public void Parse_ShouldReturnFilledLists_WhenInputIsGiven()
        {
            var input = new List<string>()
            {
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9"
            };

            var expected = new List<Report>()
            {
                new Report("7 6 4 2 1"),
                new Report("1 2 7 8 9"),
                new Report("9 7 6 2 1"),
                new Report("1 3 2 4 5"),
                new Report("8 6 4 4 1"),
                new Report("1 3 6 7 9")
        };

            var sut = new InputParser(input);
            var parsed = sut.Parse();
            parsed.Should().BeEquivalentTo(expected);
        }
    }
}
