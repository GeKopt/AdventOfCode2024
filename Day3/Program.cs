using Day3;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var multiplies = new InputParser(input).Parse();
        Console.WriteLine(multiplies.Sum());
    }
}