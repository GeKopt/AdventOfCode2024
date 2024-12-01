using Day1;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);

        var parser = new InputParser(input);
        var locations = parser.Parse();
        //Part1(locations);
        Part2(locations);
    }

    private static void Part1(Locations locations)
    {
        var calculator = new DistanceCalculator();
        Console.WriteLine(calculator.CalculateTotalDistance(locations));
    }

    private static void Part2(Locations locations)
    {
        var calculator = new SimilarityCalculator(locations);
        Console.WriteLine(calculator.CalculateTotalSimilarityScore());
    }
}