namespace Day9
{
    public class FileBlock
    {
        public bool IsEmpty => Id == -1;
        public int Id { get; } = -1;

        public FileBlock()
        {
        }

        public FileBlock(int id)
        {
            Id = id;    
        }
    }
}
