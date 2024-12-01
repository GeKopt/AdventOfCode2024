using Day1;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day1
{
    public class InputParserTests
    {
        [Test]
        public void Parse_ShouldReturnFilledLists_WhenInputIsGiven()
        {
            var input = new List<string>()
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };

            var expected = new Locations()
            {
                Left = new List<int>() { 3, 4, 2, 1, 3, 3 },
                Right = new List<int> { 4, 3, 5, 3, 9, 3 }
            };

            var sut = new InputParser(input);
            var parsed = sut.Parse();
            parsed.Should().BeEquivalentTo(expected);
        }
    }
}
