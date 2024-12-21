using Day10;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day10
{
    internal class HikesTests
    {
        public static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData(new List<string>()
                {
                    "1066966",
                    "2664846",
                    "3111711",
                    "4567654",
                    "1118113",
                    "6669662",
                    "6666601"
                }, 3);
                yield return new TestCaseData(new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 36);
            }
        }

        public static IEnumerable<TestCaseData> RatingCases
        {
            get
            {
                yield return new TestCaseData(new List<string>()
                {
                    "012345",
                    "123456",
                    "234567",
                    "345678",
                    "416789",
                    "567891",
                }, 227);
                yield return new TestCaseData(new List<string>()
                {
                    "89010123",
                    "78121874",
                    "87430965",
                    "96549874",
                    "45678903",
                    "32019012",
                    "01329801",
                    "10456732"
                }, 81);
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void GetTotalHikes_ShouldReturnTotalHikes_WhenMapContainsMultipleHikes(List<string> mapLayout, int expected)
        {
            var map = new Map(mapLayout);
            var sut = new Hikes(map);
            sut.GetTotalHikes().Should().Be(expected);
        }

        [TestCaseSource(nameof(RatingCases))]
        public void GetTotalRatings_ShouldReturnTotalRatings_WhenMapContainsMultipleHikes(List<string> mapLayout, int expected)
        {
            var map = new Map(mapLayout);
            var sut = new Hikes(map);
            sut.GetTotalRating().Should().Be(expected);
        }
    }
}
