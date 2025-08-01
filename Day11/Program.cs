using Day11;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile).First();

        var numbers = input.Split(' ');
        var stones = new List<long>();
        foreach(var number in numbers ) 
        {
            stones.Add(long.Parse(number));
        }
        var blinker = new Blinker(stones);
        Console.WriteLine("Part 1");
        Console.WriteLine(blinker.Blink(25));

        blinker = new Blinker(stones);
        Console.WriteLine("Part 2");
        Console.WriteLine(blinker.Blink(75));

    }
}