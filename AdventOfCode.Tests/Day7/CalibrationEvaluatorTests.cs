using Day7;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Day7
{
    public class CalibrationEvaluatorTests
    {
        public static IEnumerable ValidCases
        {
            get
            {
                yield return new TestCaseData(190, new List<long> { 10, 19 });
                yield return new TestCaseData(3267, new List<long> { 81, 40, 27 });
                yield return new TestCaseData(292, new List<long> { 11, 6, 16, 20 });
            }
        }

        public static IEnumerable InValidCases
        {
            get
            {
                yield return new TestCaseData(83, new List<long> { 17, 5 });
                yield return new TestCaseData(156, new List<long> { 15, 6 });
                yield return new TestCaseData(7290, new List<long> { 6, 8, 6, 15 });
                yield return new TestCaseData(161011, new List<long> { 16, 10, 13 });
                yield return new TestCaseData(192, new List<long> { 17, 8, 14 });
                yield return new TestCaseData(21037, new List<long> { 9, 7, 18, 13 });
            }
        }

        [TestCaseSource(nameof(ValidCases))]
        public void IsValidCalibration_ShouldReturnTrue_WhenCalibrationIsValid(long total, List<long> values)
        {
            var sut = new CalibrationEvaluator();
            sut.IsValidCalibration(total, values).Should().BeTrue();
        }

        [TestCaseSource(nameof(InValidCases))]
        public void IsValidCalibration_ShouldReturnFalse_WhenCalibrationIsInValid(long total, List<long> values)
        {
            var sut = new CalibrationEvaluator();
            sut.IsValidCalibration(total, values).Should().BeFalse();
        }

    }
}
