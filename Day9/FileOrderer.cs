namespace Day9
{
    public class FileOrderer
    {
        private List<FileBlock> _files;

        public FileOrderer(List<FileBlock> files)
        {
            _files = files;
        }

        public List<FileBlock> OrderFragmented()
        {
            var copiedFiles = _files.ToList();
            var orderedFiles = new List<FileBlock>();
            for (int index = 0; index < copiedFiles.Count; index++)
            {
                var currentFile = copiedFiles[index];
                if (currentFile.IsEmpty)
                {
                    var lastFileIndex = copiedFiles.FindLastIndex(file => !file.IsEmpty && file.Size >= currentFile.Size);
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
            FilePresenter.Print(copiedFiles);
            return orderedFiles;
        }

        public List<FileBlock> OrderByBlock()
        {
            var idsDone = new HashSet<int>();
            var copiedFiles = _files.ToList();
            for (int index = 0; index < copiedFiles.Count; index++)
            {
                var currentFile = copiedFiles[index];
                if (idsDone.Contains(currentFile.Id))
                {
                    continue;
                }
                if (!currentFile.IsEmpty)
                {
                    continue;
                }
                var filledSpotToFill = copiedFiles.FindLastIndex(file => !file.IsEmpty && file.Size <= currentFile.Size);
                if (filledSpotToFill == -1 || filledSpotToFill < index)
                {
                    continue;
                }

                var foundFile = copiedFiles[filledSpotToFill];
                for(int current = index; current < (index + foundFile.Size); current++)
                {
                    copiedFiles[current] = foundFile;
                }
                for (int current = filledSpotToFill; current > (filledSpotToFill - foundFile.Size); current--)
                {
                    copiedFiles[current] = new FileBlock(-1,currentFile.Size);
                }
                currentFile.RemoveBlocks(foundFile.Size);
                idsDone.Add(foundFile.Id);
            }
            FilePresenter.Print(copiedFiles);
            return copiedFiles;
        }
    }
}
