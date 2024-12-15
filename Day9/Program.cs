using Day9;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile).First();
        var fileSystem = new FileSystem(input);
        var orderer = new FileOrderer(fileSystem.Files);
        var calculator = new ChecksumCalculator(orderer.Order());
        Console.WriteLine(calculator.Calculate());
    }
}