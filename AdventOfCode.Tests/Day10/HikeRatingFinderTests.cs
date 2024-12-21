using Day10;
using FluentAssertions;
using System.Drawing;

namespace AdventOfCode.Tests.Day10
{
    internal class HikeRatingFinderTests
    {
        public static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData(new Point(3, 0), new List<string>()
                {
                    "8880",
                    "4321",
                    "5882",
                    "6543",
                    "7114",
                    "8765",
                    "9111"
                }, 3);
                yield return new TestCaseData(new Point(3, 0), new List<string>()
                {
                    "1190449",
                    "4441498",
                    "1112117",
                    "6543456",
                    "7651987",
                    "8761111",
                    "9871111"
                }, 13);
                yield return new TestCaseData(new Point(0, 0), new List<string>()
                {
                    "012345",
                    "123456",
                    "234567",
                    "345678",
                    "416789",
                    "567891",
                }, 227);
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
                }, 20);
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
                }, 24);
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
                }, 10);
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
                }, 4);
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
                }, 4);
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
                }, 8);
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
        public void GetRating_ShouldReturnCorrectRating_WhenMapHasOneTrailhead(Point start, List<string> mapLayout, int expected)
        {
            var map = new Map(mapLayout);
            var sut = new HikeRatingFinder(map);
            sut.GetRating(start).Should().Be(expected);
        }
    }
}
