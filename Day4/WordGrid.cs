namespace Day4
{
    public class WordGrid
    {
        public char[,] Letters;

        public WordGrid(List<string> rows)
        {
            Letters = new char[rows.First().Length, rows.Count];
            FillGrid(rows);
        }

        private void FillGrid(List<string> rows)
        {
            for (int rowIndex = 0; rowIndex < rows.Count(); rowIndex++)
            {
                var row = rows[rowIndex];
                for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    Letters[rowIndex, columnIndex] = row[columnIndex];
                }
            }
        }
    }
}
