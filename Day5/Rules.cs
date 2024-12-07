namespace Day5
{
    public class Rules
    {
        public readonly Dictionary<int, List<int>> _rules = new Dictionary<int, List<int>>();

        public Rules(List<string> rules)
        {
            ParseRules(rules);
        }

        private void ParseRules(List<string> rules)
        {
            foreach (var rule in rules)
            {
                var split = rule.Split('|');
                var key = int.Parse(split[0]);
                var value = int.Parse(split[1]);
                if (_rules.ContainsKey(key))
                {
                    _rules[key].Add(value);
                }
                else
                {
                    _rules.Add(key, new List<int>() { value });
                }
            }
        }

        public List<int> GetRule(int page)
        {
            return _rules[page];
        }

        public bool IsWithinRule(int currentPage, int targetPage)
        {
            if (!_rules.ContainsKey(currentPage))
            {
                return false;
            }
            return _rules[currentPage].Contains(targetPage);
        }
    }
}
