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

        var total = 0L;
        foreach (var calibration in calibrations)
        {
            if(new CalibrationEvaluator().IsValidCalibration(calibration))
            {
                total += calibration.Total;
            }
        }
        Console.WriteLine(total);
    }
}