namespace Day5
{
    public class PageOrderChecker
    {
        private Rules _rules;

        public PageOrderChecker(Rules rules)
        {
            _rules = rules;
        }

        public bool IsValidOrder(List<int> pages)
        {
            return GetInvalidPages(pages).Count == 0;
        }

        public List<int> GetInvalidPages(List<int> pages)
        {
            var invalidPages = new List<int>();
            for (int index = 0; index < pages.Count; index++)
            {
                var currentPageNumber = pages[index];
                if (pages.GetRange(0, index).Any(pageNumber => _rules.IsWithinRule(currentPageNumber, pageNumber)))
                {
                    invalidPages.Add(currentPageNumber);
                }
            }
            return invalidPages;
        }
    }
}
