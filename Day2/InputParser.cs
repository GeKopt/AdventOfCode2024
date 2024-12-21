namespace Day2
{
    public class InputParser
    {
        private IEnumerable<string> _input;
        public InputParser(IEnumerable<string> input)
        {
            _input = input;
        }

        public List<Report> Parse()
        {
            var reports = new List<Report>();
            foreach (var line in _input)
            {
                reports.Add(new Report(line));
            }
            return reports;
        }
    }
}
