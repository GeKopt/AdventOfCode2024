using Day3;

namespace Day3
{
    public class InputParser
    {
        private IEnumerable<string> _input;
        public InputParser(IEnumerable<string> input)
        {
            _input = input;
        }

        public IEnumerable<long> Parse()
        {
            foreach(var line in _input)
            {
                var startIndex = 0;
                int nextMulIndex;
                while ((nextMulIndex = line.IndexOf("mul(", startIndex)) != -1)
                {
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
                    yield return source * target;
                }
            }            
        }
    }
}
