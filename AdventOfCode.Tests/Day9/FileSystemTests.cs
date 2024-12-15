using Day7;
using Day9;
using FluentAssertions;

namespace AdventOfCode.Tests.Day9
{
    public class FileSystemTests
    {
        public static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData("2333133121414131402", new List<FileBlock>()
                {
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(2),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(),
                    new FileBlock(4),
                    new FileBlock(4),
                    new FileBlock(),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(9),
                    new FileBlock(9)
                });
                yield return new TestCaseData("12345", new List<FileBlock>()
                {
                    new FileBlock(0),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(),
                    new FileBlock(2),
                    new FileBlock(2),
                    new FileBlock(2),
                    new FileBlock(2),
                    new FileBlock(2)
                });
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void FileSystem_ShouldParseFilesCorrectly_WhenFilesAreGiven(string files, List<FileBlock> expected)
        {
            var sut = new FileSystem(files);
            sut.Files.Should().BeEquivalentTo(expected);
        }
    }
}
