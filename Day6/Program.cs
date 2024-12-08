using Day6;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var map = new Map(input.ToList());

        var navigatorMap = map.Clone();
        var navigator = new GuardNavigator(navigatorMap);
        navigator.Navigate();
        Console.WriteLine(navigatorMap.GetMappedPositions());

        var loopMap = map.Clone();
        var loopFinder = new LoopFinder(loopMap);
        Console.WriteLine(loopFinder.FindLoops());
    }
}