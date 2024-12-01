using Day1;
using FluentAssertions;

namespace AdventOfCode.Tests.Day1
{
    public class SimilarityCalculatorTests
    {
        [Test]
        public void CalculateSimilatiryScore_ShouldCalculateCorrectSimilarityScore_WhenTwoLocationIdsAreGiven()
        {
            var locations = new Locations()
            {
                Left = new List<int>() { 3, 4, 2, 1, 3, 3 },
                Right = new List<int>() { 4, 3, 5, 3, 9, 3 }
            };

            var sut = new SimilarityCalculator(locations);
            var similarityScore = sut.CalculateSimilatiryScore(3);
            similarityScore.Should().Be(9);
        }

        [Test]
        public void CalculateTotal_ShouldCalculateCorrectTotal_WhenTwoListsAreGiven()
        {
            var locations = new Locations()
            {
                Left = new List<int>() { 3, 4, 2, 1, 3, 3 },
                Right = new List<int>() { 4, 3, 5, 3, 9, 3 }
            };
            var sut = new SimilarityCalculator(locations);
            var total = sut.CalculateTotalSimilarityScore();
            total.Should().Be(31);
        }

    }
}