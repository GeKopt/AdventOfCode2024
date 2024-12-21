using Day8;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile).ToList();

        PartOne(input);
        PartTwo(input);

    }

    private static void PartOne(List<string> input)
    {
        var map = new Map(input);
        var mapper = new AntinodeMapper(map, false);
        mapper.MapAntinodes();
        Console.WriteLine(map.GetTotalAntinodes().ToString());
        Console.WriteLine(map.ToString());
    }

    private static void PartTwo(List<string> input)
    {
        var map = new Map(input);
        var mapper = new AntinodeMapper(map, true);
        mapper.MapAntinodes();
        Console.WriteLine(map.GetTotalAntinodes().ToString());
        Console.WriteLine(map.ToString());
    }
}