using Day10;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile).ToList();

        var map = new Map(input);
        var hikes = new Hikes(map);
        Console.WriteLine(hikes.GetTotalHikes());
    }
}