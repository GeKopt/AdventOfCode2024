namespace Day9
{
    public class ChecksumCalculator
    {
        private List<FileBlock> _files;

        public ChecksumCalculator(List<FileBlock> files)
        {
            _files = files;
        }

        public long Calculate()
        {
            var checksum = 0L;
            for(int index = 0; index < _files.Count; index++)
            {
                var currentFile = _files[index];
                if (currentFile.IsEmpty)
                {
                    break;
                }
                checksum += index * currentFile.Id;
            }
            return checksum;
        }
    }
}
