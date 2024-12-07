using Day5;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day5
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class PageOrdererTests
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

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<int>() { 75, 97, 47, 61, 53 }, new List<int>() { 97, 75, 47, 61, 53 });
                yield return new TestCaseData(new List<int>() { 61, 13, 29 }, new List<int>() { 61, 29, 13 });
                yield return new TestCaseData(new List<int>() { 97, 13, 75, 29, 47 }, new List<int>() { 97, 75, 47, 29, 13 });
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public void Order_ShouldReturnOrderedPages_WhenInvalidOrderedPagesAreGiven(List<int> pages, List<int> expected)
        {
            var rules = new Rules(_rules);
            var sut = new PageOrderer(rules, pages);
            sut.Order().Should().BeEquivalentTo(expected);
        }
    }
}
