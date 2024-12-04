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
    public class MasFinderTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<string>()
                {
                    "M.S",
                    ".A.",
                    "M.S",
                })
                { TestName = "East" };
                yield return new TestCaseData(new List<string>()
                {
                    "S.M",
                    ".A.",
                    "S.M",
                })
                { TestName = "West" };
             }
        }

        [TestCaseSource(nameof(TestCases))]
        public void FindOccurances_ShouldReturnOne_WhenOneXIsAvailable(List<string> rows)
        {
            var grid = new WordGrid(rows);
            var sut = new MasFinder(grid);
            sut.FindOccurances().Should().Be(1);
        }
    }
}
