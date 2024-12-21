using Day10;
using FluentAssertions;
using System.Drawing;

namespace AdventOfCode.Tests.Day10
{
    internal class HikePathFinderTest
    {
        public static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData(new Point(0, 0), new List<string>()
                {
                    "0123",
                    "1234",
                    "8765",
                    "9876"
                }, 1);
                yield return new TestCaseData(new Point(3, 0), new List<string>()
                {
                    "8880888",
                    "8881888",
                    "8882888",
                    "6543456",
                    "7888887",
                    "8222228",
                    "9222229"
                }, 2);
                yield return new TestCaseData(new Point(3, 0), new List<string>()
                {
                    "1190449",
                    "4441498",
                    "1112117",
                    "6543456",
                    "7651987",
                    "8761111",
                    "9871111"
                }, 4);
                yield return new TestCaseData(new Point(0, 1), new List<string>()
                {
                    "1066966",
                    "2664846",
                    "3111711",
                    "4567654",
                    "1118113",
                    "6669662",
                    "6666601"
                }, 1);
                yield return new TestCaseData(new Point(5, 6), new List<string>()
                {
                    "1066966",
                    "2664846",
                    "3111711",
                    "4567654",
                    "1118113",
                    "6669662",
                    "6666601"
                }, 2);
                yield return new TestCaseData(new Point(2, 0), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 5);
                yield return new TestCaseData(new Point(4, 0), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 6);
                yield return new TestCaseData(new Point(4, 2), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 5);
                yield return new TestCaseData(new Point(6, 4), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 3);
                yield return new TestCaseData(new Point(2, 5), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 1);
                yield return new TestCaseData(new Point(5, 5), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 3);
                yield return new TestCaseData(new Point(0, 6), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 5);
                yield return new TestCaseData(new Point(6, 6), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 3);
                yield return new TestCaseData(new Point(1, 7), new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 5);
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void GetPossibleHikePaths_ShouldReturnCorrectAmountOfPaths_WhenMapHasOneTrailhead(Point start, List<string> mapLayout, int expected)
        {
            var map = new Map(mapLayout);
            var sut = new HikePathFinder(map);
            sut.GetPossibleHikePaths(start).Should().Be(expected);
        }
    }
}
