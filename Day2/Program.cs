using Day2;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var reports = new InputParser(input).Parse();
        Console.WriteLine(reports.Count(report => report.IsSafe()));
    }
}