using Day5;
using FluentAssertions;

namespace AdventOfCode.Tests.Day5
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class PageOrderCheckerTests
    {
        private List<string> _rules = new List<string>()
        {
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13"
        };

        [TestCase("75,47,61,53,29")]
        [TestCase("97,61,53,29,13")]
        [TestCase("75,29,13")]
        public void IsValidOrder_ShouldReturnTrue_WhenOrderIsValid(string pages)
        {
            var rules = new Rules(_rules);
            var parser = new PagesParser(pages);
            var sut = new PageOrderChecker(rules);
            sut.IsValidOrder(parser.Parse()).Should().BeTrue();
        }

        [TestCase("75,97,47,61,53")]
        [TestCase("61,13,29")]
        [TestCase("97,13,75,29,47")]
        public void IsValidOrder_ShouldReturnFalse_WhenOrderIsValid(string pages)
        {
            var rules = new Rules(_rules);
            var parser = new PagesParser(pages);
            var sut = new PageOrderChecker(rules);
            sut.IsValidOrder(parser.Parse()).Should().BeFalse();
        }
    }
}
