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
                yield return new TestCaseData("2333133121414131402", new List<int>() { 0, 0, -1, -1, -1, 1, 1, 1, -1, -1, -1, 2, -1, -1, -1, 3, 3, 3, -1, 4, 4, -1, 5, 5, 5, 5, -1, 6, 6, 6, 6, -1, 7, 7, 7, -1, 8, 8, 8, 8, 9, 9 });
                yield return new TestCaseData("12345", new List<int>() { 0, -1, -1, 1, 1, 1, -1, -1, -1, -1, 2, 2, 2, 2, 2 });
            }
        }

        [TestCaseSource(nameof(Cases))]
        public void FileSystem_ShouldParseFilesCorrectly_WhenFilesAreGiven(string files, List<int> expected)
        {
            var sut = new FileSystem(files);
            sut.Files.Select(file => file.Id).Should().BeEquivalentTo(expected);
        }
    }
}
