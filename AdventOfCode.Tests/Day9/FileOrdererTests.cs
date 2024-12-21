using Day9;
using FluentAssertions;

namespace AdventOfCode.Tests.Day9
{
    internal class FileOrdererTests
    {
        public static IEnumerable<TestCaseData> FragmentedCases
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

        [TestCaseSource(nameof(FragmentedCases))]
        public void OrderFragmented_ShouldOrderFilesCorrectly_WhenFilesContainEmptySpaces(List<FileBlock> files, List<FileBlock> expected)
        {
            var sut = new FileOrderer(files);
            sut.OrderFragmented().Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<TestCaseData> BlockCases
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
                    new FileBlock(2),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(1),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(7),
                    new FileBlock(0),
                    new FileBlock(4),
                    new FileBlock(4),
                    new FileBlock(0),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(3),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(5),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(6),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(0),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(8),
                    new FileBlock(0),
                    new FileBlock(0)
                });
            }
        }

        [Test]
        public void OrderByBlock_ShouldOrderFilesCorrectly_WhenFilesContainEmptySpaces()
        {
            var firstFile = new FileBlock(0, 2);
            var firstEmpty = new FileBlock(-1, 3);
            var secondFile = new FileBlock(1, 3);
            var secondEmpty = new FileBlock(-1, 3);
            var thirthFile = new FileBlock(2, 1);
            var thirthEmpty = new FileBlock(-1, 3);
            var fourthFile = new FileBlock(3, 3);
            var fourthEmpty = new FileBlock(-1, 1);
            var fifthFile = new FileBlock(4, 2);
            var fifthEmpty = new FileBlock(-1, 1);
            var sixthFile = new FileBlock(5, 4);
            var sixthEmpty = new FileBlock(-1, 1);
            var seventhFile = new FileBlock(6, 4);
            var seventhEmpty = new FileBlock(-1, 1);
            var eightFile = new FileBlock(7, 3);
            var eightEmpty = new FileBlock(-1, 1);
            var ninethFile = new FileBlock(8, 4);
            var tenthFile = new FileBlock(9, 2);

            var files = new List<FileBlock>()
                {
                    firstFile,
                    firstFile,
                    firstEmpty,
                    firstEmpty,
                    firstEmpty,
                    secondFile,
                    secondFile,
                    secondFile,
                    secondEmpty,
                    secondEmpty,
                    secondEmpty,
                    thirthFile,
                    thirthEmpty,
                    thirthEmpty,
                    thirthEmpty,
                    fourthFile,
                    fourthFile,
                    fourthFile,
                    fourthEmpty,
                    fifthFile,
                    fifthFile,
                    fifthEmpty,
                    sixthFile,
                    sixthFile,
                    sixthFile,
                    sixthFile,
                    sixthEmpty,
                    seventhFile,
                    seventhFile,
                    seventhFile,
                    seventhFile,
                    seventhEmpty,
                    eightFile,
                    eightFile,
                    eightFile,
                    eightEmpty,
                    ninethFile,
                    ninethFile,
                    ninethFile,
                    ninethFile,
                    tenthFile,
                    tenthFile
                };

            var expected = new List<int>() { 0, 0, 9, 9, 2, 1, 1, 1, 7, 7, 7, -1, 4, 4, -1, 3, 3, 3, -1, -1, -1, -1, 5, 5, 5, 5, -1, 6, 6, 6, 6, -1, -1, -1, -1, -1, 8, 8, 8, 8, -1, -1 };
            var sut = new FileOrderer(files);
            var ordered = sut.OrderByBlock();
            ordered.Select(file => file.Id).Should().BeEquivalentTo(expected);
        }


        [Test]
        public void OrderByBlock_ShouldOrderFilesCorrectly_WhenFilesContainEmptySpaces2()
        {
            var firstFile = new FileBlock(0, 1);
            var firstEmpty = new FileBlock(-1, 3);
            var secondFile = new FileBlock(1, 1);
            var secondEmpty = new FileBlock(-1, 3);
            var thirthFile = new FileBlock(2, 1);
            var thirthEmpty = new FileBlock(-1, 6);
            var fourthFile = new FileBlock(3, 5);

            var files = new List<FileBlock>()
                {
                    firstFile,
                    firstEmpty,
                    firstEmpty,
                    firstEmpty,
                    secondFile,
                    secondEmpty,
                    secondEmpty,
                    secondEmpty,
                    thirthFile,
                    thirthEmpty,
                    thirthEmpty,
                    thirthEmpty,
                    thirthEmpty,
                    thirthEmpty,
                    thirthEmpty,
                    fourthFile,
                    fourthFile,
                    fourthFile,
                    fourthFile,
                    fourthFile
                };

            var expected = new List<int>() { 0, 2, 1, -1, -1, -1, -1, -1, -1, 3, 3, 3, 3, 3, -1, -1, -1, -1, -1, -1 };
            var sut = new FileOrderer(files);
            var ordered = sut.OrderByBlock().Select(file => file.Id);
            ordered.Should().BeEquivalentTo(expected);
        }
    }
}
