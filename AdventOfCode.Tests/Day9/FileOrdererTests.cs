using Day9;
using FluentAssertions;

namespace AdventOfCode.Tests.Day9
{
    internal class FileOrdererTests
    {
        public static IEnumerable<TestCaseData> Cases
        {
            get
            {
                yield return new TestCaseData(new List<FileBlock>()
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
                },
                new List<FileBlock>()
                { 
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(9),
                    new FileBlock(9),
                    new FileBlock(8),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(2),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(6),
                    new FileBlock(4),
                    new FileBlock(4),
                    new FileBlock(6),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(6),
                    new FileBlock(6)
                });

                yield return new TestCaseData(new List<FileBlock>()
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
                }, 
                new List<FileBlock>()
                {
                    new FileBlock(0),
                    new FileBlock(2),
                    new FileBlock(2),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(2),
                    new FileBlock(2),
                    new FileBlock(2)
                });
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void OrderFiles_ShouldOrderFilesCorrectly_WhenFilesContainEmptySpaces(List<FileBlock> files, List<FileBlock> expected)
        {
            var sut = new FileOrderer(files);
            sut.Order().Should().BeEquivalentTo(expected);
        }
    }
}
