namespace Day9
{
    public class FileSystem
    {
        public List<FileBlock> Files = new List<FileBlock>();
        public const char Empty = '.';

        public FileSystem(string files)
        {
            ParseFile(files);
        }

        private void ParseFile(string files)
        {
            var currentId = 0;
            for (int currentIndex = 0; currentIndex < files.Length; currentIndex++)
            {
                var size = int.Parse(files[currentIndex].ToString());
                var file = default(FileBlock);
                if (currentIndex % 2 == 0)
                {
                    file = new FileBlock(currentId);
                    currentId++;
                }
                else
                {
                    file = new FileBlock();
                }

                for (int current = 0; current < size; current++)
                {
                    Files.Add(file);
                }
            }
        }
    }
}
