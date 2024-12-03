using Day3;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var multiplies = new InputParser(input).Parse(useEnabledState: false);
        Console.WriteLine(multiplies.Sum());

        multiplies = new InputParser(input).Parse(useEnabledState: true);
        Console.WriteLine(multiplies.Sum());

    }
}