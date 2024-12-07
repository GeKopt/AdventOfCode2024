using Day5;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string inputFile = "input.txt";
        var input = File.ReadLines(inputFile);
        var ruleInput = input.Where(line => line.Contains('|'));
        var rules = new Rules(ruleInput.ToList());
        var pages = input.Where(line => line.Contains(','));

        var total = CalculateTotalValidMedian(rules, pages);
        Console.WriteLine(total);

        total = CalculateTotalReorderedMedian(rules, pages);
        Console.WriteLine(total);
    }

    private static int CalculateTotalReorderedMedian(Rules rules, IEnumerable<string> pages)
    {
        var total = 0;
        foreach (var page in pages)
        {
            var parsedPages = new PagesParser(page).Parse();
            if (!new PageOrderChecker(rules).IsValidOrder(parsedPages))
            {
                var reOrderedPages = new PageOrderer(rules, parsedPages).Order();
                total += reOrderedPages[reOrderedPages.Count / 2];
            }
        }
        return total;
    }

    private static int CalculateTotalValidMedian(Rules rules, IEnumerable<string> pages)
    {
        var total = 0;
        foreach (var page in pages)
        {
            var parsedPages = new PagesParser(page).Parse();
            if (new PageOrderChecker(rules).IsValidOrder(parsedPages))
            {
                total += parsedPages[parsedPages.Count / 2];
            }
        }
        return total;
    }
}