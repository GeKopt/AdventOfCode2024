using Day1;
using FluentAssertions;

namespace AdventOfCode.Tests.Day1
{
    public class DistanceCalculatorTests
    {
        [Test]
        public void CalculateDistance_ShouldCalculateCorrectSmallerDistance_WhenTwoLocationIdsAreGiven()
        {
            int left = 1;
            int right = 3;

            var sut = new DistanceCalculator();
            var distance = sut.CalculateDistance(left, right);
            distance.Should().Be(2);
        }

        [Test]
        public void CalculateTotal_ShouldCalculateCorrectTotal_WhenTwoListsAreGiven()
        {
            var locations = new Locations()
            {
                Left = new List<int>() { 3, 4, 2, 1, 3, 3 },
                Right = new List<int>() { 4, 3, 5, 3, 9, 3 }
            };
            var sut = new DistanceCalculator();
            var total = sut.CalculateTotalDistance(locations);
            total.Should().Be(11);
        }

    }
}