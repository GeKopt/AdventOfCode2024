namespace Day7
{
    public class InputParser
    {
        private List<string> _lines;

        public InputParser(List<string> lines)
        {
            _lines = lines;
        }

        public List<Calibration> Parse()
        {
            var calibrations = new List<Calibration>();
            foreach (var line in _lines)
            {
                var splitColon = line.Split(": ");
                var total = long.Parse(splitColon[0]);
                var values = splitColon[1].Split(' ').Select(value => long.Parse(value)).ToList();
                calibrations.Add(new Calibration(total, values));
            }
            return calibrations;
        }
    }
}
