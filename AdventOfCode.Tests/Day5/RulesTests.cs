using Day5;
using FluentAssertions;

namespace AdventOfCode.Tests.Day5
{
    public class RulesTests
    {
        [Test]
        public void GetRule_ShouldReturnCorrectRule_WhenPageIsGiven()
        {
            var rules = new List<string>()
            {
                "1|2",
                "1|3",
                "1|4",
                "2|3",
                "2|4",
            };

            var expected = new List<int>() { 3, 4 };
            var sut = new Rules(rules);
            var pages = sut.GetRule(2);
            pages.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void IsWithinRule_ShouldReturnTrue_WhenPageIsWithinRule()
        {
            var rules = new List<string>()
            {
                "1|2"
            };

            var sut = new Rules(rules);
            var pages = sut.IsWithinRule(1, 2);
            pages.Should().BeTrue();
        }

        [Test]
        public void IsWithinRule_ShouldReturnFalse_WhenPageIsNotWithinRule()
        {
            var rules = new List<string>()
            {
                "1|2"
            };

            var sut = new Rules(rules);
            var pages = sut.IsWithinRule(1, 5);
            pages.Should().BeFalse();
        }
    }
}
