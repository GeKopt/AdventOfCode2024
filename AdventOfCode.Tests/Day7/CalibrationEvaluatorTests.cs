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
                yield return new TestCaseData(new Calibration(190, new List<long> { 10, 19 }));
                yield return new TestCaseData(new Calibration(3267, new List<long> { 81, 40, 27 }));
                yield return new TestCaseData(new Calibration(292, new List<long> { 11, 6, 16, 20 }));
            }
        }

        public static IEnumerable InValidCases
        {
            get
            {
                yield return new TestCaseData(new Calibration(83, new List<long> { 17, 5 }));
                yield return new TestCaseData(new Calibration(156, new List<long> { 15, 6 }));
                yield return new TestCaseData(new Calibration(7290, new List<long> { 6, 8, 6, 15 }));
                yield return new TestCaseData(new Calibration(161011, new List<long> { 16, 10, 13 }));
                yield return new TestCaseData(new Calibration(192, new List<long> { 17, 8, 14 }));
                yield return new TestCaseData(new Calibration(21037, new List<long> { 9, 7, 18, 13 }));
            }
        }

        public static IEnumerable ValidCasesWithConcat
        {
            get
            {
                yield return new TestCaseData(new Calibration(156, new List<long> { 15, 6 })) {TestName = "1" } ;
                yield return new TestCaseData(new Calibration(7290, new List<long> { 6, 8, 6, 15 })) { TestName = "2" };
                yield return new TestCaseData(new Calibration(192, new List<long> { 17, 8, 14 })) { TestName = "3" };
            }
        }

        [TestCaseSource(nameof(ValidCases))]
        public void IsValidCalibration_ShouldReturnTrue_WhenCalibrationIsValid(Calibration calibration)
        {
            var sut = new CalibrationEvaluator();
            sut.IsValidCalibration(calibration).Should().BeTrue();
        }

        [TestCaseSource(nameof(InValidCases))]
        public void IsValidCalibration_ShouldReturnFalse_WhenCalibrationIsInValid(Calibration calibration)
        {
            var sut = new CalibrationEvaluator();
            sut.IsValidCalibration(calibration).Should().BeFalse();
        }

        [TestCaseSource(nameof(ValidCasesWithConcat))]
        public void IsValidCalibration_ShouldReturnFalse_WhenCalibrationIsValidWithConcatination(Calibration calibration)
        {
            var sut = new CalibrationEvaluator();
            sut.IsValidCalibrationWithConcatination(calibration).Should().BeTrue();
        }
    }
}
