using Day4;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day4
{
    public class ChristmasFinderTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<string>()
                {
                    "XMAS",
                    "....",
                    "....",
                    "...."
                })
                { TestName = "East" };
                yield return new TestCaseData(new List<string>()
                {
                    "SAMX",
                    "....",
                    "....",
                    "...."
                })
                { TestName = "West" };
                yield return new TestCaseData(new List<string>()
                {
                    "X...",
                    "M...",
                    "A...",
                    "S...",
                })
                { TestName = "South" };
                yield return new TestCaseData(new List<string>()
                {
                    "S...",
                    "A...",
                    "M...",
                    "X...",
                })
                { TestName = "North" };
                yield return new TestCaseData(new List<string>()
                {
                    "X...",
                    ".M..",
                    "..A.",
                    "...S",
                })
                { TestName = "SouthEast" };
                yield return new TestCaseData(new List<string>()
                {
                    "...S",
                    "..A.",
                    ".M..",
                    "X...",
                })
                { TestName = "NorthEast" };
                yield return new TestCaseData(new List<string>()
                {
                    "...X",
                    "..M.",
                    ".A..",
                    "S...",
                })
                { TestName = "SouthWest" };
                yield return new TestCaseData(new List<string>()
                {
                    "S...",
                    ".A..",
                    "..M.",
                    "...X",
                })
                { TestName = "NorthWest" };
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public void FindOccurances_ShouldReturnOneOccurance_WhenGridWithOneXmasIsGiven(List<string> directional)
        {
            var grid = new WordGrid(directional);
            var sut = new ChristmasFinder(grid);
            sut.FindOccurances().Should().Be(1);
        }

        [Test]
        public void FindOccurances_ShouldReturnCorrectAmountOfOccurances_WhenGridIsFilled()
        {
            var rows = new List<string>
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };

            var grid = new WordGrid(rows);
            var sut = new ChristmasFinder(grid);
            sut.FindOccurances().Should().Be(18);
        }
    }
}
