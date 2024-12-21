namespace Day9
{
    public class FileBlock
    {
        public bool IsEmpty => Id == -1;
        public int Id { get; } = -1;
        public int Size { get; private set; } = 0;
        public FileBlock()
        {
        }

        public FileBlock(int id)
        {
            Id = id;
        }

        public FileBlock(int id, int size)
        {
            Id = id;
            Size = size;
        }

        public void AddBlock()
        {
            Size++;
        }

        public void RemoveBlocks(int number)
        {
            Size -= number;
        }

        public IEnumerable<FileBlock> ToSeparateFiles()
        {
            for (int index = 0; index < Size; index++)
            {
                yield return this;
            }
        }
    }
}
