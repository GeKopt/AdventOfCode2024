namespace Day5
{
    public class PagesParser
    {
        private string _pages;
        public PagesParser(string pages)
        {
            _pages = pages;
        }

        public List<int> Parse()
        {
            var splitPages = _pages.Split(',');
            var pageNumbers = new List<int>();
            foreach (var page in splitPages)
            {
                pageNumbers.Add(int.Parse(page));
            }
            return pageNumbers;
        }
    }
}
