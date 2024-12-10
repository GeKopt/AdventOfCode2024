using Day7;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var inputParser = new InputParser(input.ToList());
        var calibrations = inputParser.Parse();

        var invalidCalibrations = new List<Calibration>();
        var total = 0L;
        foreach (var calibration in calibrations)
        {
            if (new CalibrationEvaluator().IsValidCalibration(calibration))
            {
                total += calibration.Total;
            }
            else
            {
                invalidCalibrations.Add(calibration);
            }
        }
        Console.WriteLine("TOTAL VALID " + total);

        total = 0L;
        foreach (var calibration in calibrations)
        {
            if (new CalibrationEvaluator().IsValidCalibrationWithConcatination(calibration))
            {
                total += calibration.Total;
            }
            else
            {
                invalidCalibrations.Add(calibration);
            }
        }
        Console.WriteLine("TOTAL VALID WITH CONCAT " + total);
    }
}