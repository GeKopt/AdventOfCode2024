namespace Day5
{
    public class PageOrderer
    {
        private Rules _rules;
        private List<int> _pages;

        public PageOrderer(Rules rules, List<int> pages)
        {
            _rules = rules;
            _pages = pages;
        }

        public List<int> Order()
        {
            var orderedPages = _pages.ToList();
            var checker = new PageOrderChecker(_rules);
            while (!checker.IsValidOrder(orderedPages))
            {
                var invalidPages = checker.GetInvalidPages(orderedPages);
                foreach (var invalidPage in invalidPages)
                {
                    orderedPages.Remove(invalidPage);
                    orderedPages.Insert(0, invalidPage);
                }
            }

            return orderedPages;
        }
    }
}
