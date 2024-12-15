namespace Day9
{
    public class FileOrderer
    {
        private List<FileBlock> _files;

        public FileOrderer(List<FileBlock> files)
        {
            _files = files;
        }

        public List<FileBlock> Order()
        {
            var copiedFiles = _files.ToList();
            var orderedFiles = new List<FileBlock>();
            for (int index = 0; index < copiedFiles.Count; index++)
            {
                var currentFile = copiedFiles[index];
                if (currentFile.IsEmpty)
                {
                    var lastFileIndex = copiedFiles.FindLastIndex(file => !file.IsEmpty);
                    if (lastFileIndex == -1)
                    {
                        break;
                    }
                    if (lastFileIndex < index)
                    {
                        break;
                    }
                    orderedFiles.Add(copiedFiles[lastFileIndex]);
                    copiedFiles.RemoveAt(lastFileIndex);
                }
                else
                {
                    orderedFiles.Add(currentFile);
                }
            }
            return orderedFiles;
        }
    }
}
