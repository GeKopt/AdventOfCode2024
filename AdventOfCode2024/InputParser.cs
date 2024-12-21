namespace Day1
{
    public class InputParser
    {
        private IEnumerable<string> _input;
        public InputParser(IEnumerable<string> input)
        {
            _input = input;
        }

        public Locations Parse()
        {
            var locations = new Locations();
            foreach (var line in _input)
            {
                var split = line.Split(' ').Where(split => !string.IsNullOrEmpty(split)).ToArray();
                var left = int.Parse(split[0]);
                var right = int.Parse(split[1]);

                locations.Left.Add(left);
                locations.Right.Add(right);
            }
            return locations;
        }
    }
}
