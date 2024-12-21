namespace Day3
{
    public class InputParser
    {
        private IEnumerable<string> _input;
        private bool _isEnabled = true;

        public InputParser(IEnumerable<string> input)
        {
            _input = input;
        }

        public IEnumerable<long> Parse(bool useEnabledState)
        {
            foreach (var line in _input)
            {
                var startIndex = 0;
                int nextMulIndex;
                while ((nextMulIndex = line.IndexOf("mul(", startIndex)) != -1)
                {
                    _isEnabled = GetIsEnabled(line, startIndex, nextMulIndex);
                    nextMulIndex += 4;
                    var separatorIndex = line.IndexOf(',', nextMulIndex);
                    var endParenthesisIndex = line.IndexOf(')', separatorIndex);
                    var sourceLength = separatorIndex - nextMulIndex;
                    var targetLength = endParenthesisIndex - (separatorIndex + 1);
                    if (sourceLength == -1 || sourceLength > 3 || targetLength == -1 || targetLength > 3)
                    {
                        startIndex = nextMulIndex;
                        continue;
                    }

                    if (!int.TryParse(line.Substring(nextMulIndex, sourceLength), out int source) || !int.TryParse(line.Substring(separatorIndex + 1, targetLength), out int target))
                    {
                        startIndex = nextMulIndex;
                        continue;
                    }
                    startIndex = nextMulIndex;
                    if (useEnabledState && _isEnabled || !useEnabledState)
                    {
                        yield return source * target;
                    }
                }
            }
        }

        private bool GetIsEnabled(string line, int startIndex, int nextMulIndex)
        {
            var doIndex = line.IndexOf("do()", startIndex);
            var dontIndex = line.IndexOf("don't()", startIndex);
            if (doIndex != -1 && doIndex < GetLowest(nextMulIndex, dontIndex))
            {
                return true;
            }
            else if (dontIndex != -1 && dontIndex < GetLowest(nextMulIndex, doIndex))
            {
                return false;
            }
            return _isEnabled;
        }

        private int GetLowest(int nextMulIndex, int index)
        {
            if (index == -1)
            {
                return nextMulIndex;
            }
            return Math.Min(index, nextMulIndex);
        }
    }
}
