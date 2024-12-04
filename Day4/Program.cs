using Day4;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var grid = new WordGrid(input.ToList());
        var christmasFinder = new ChristmasFinder(grid);
        Console.WriteLine(christmasFinder.FindOccurances());

        var masFinder = new MasFinder(grid);
        Console.WriteLine(masFinder.FindOccurances());

    }
}