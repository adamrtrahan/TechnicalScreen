using Questions.models;
using System.Threading.Tasks;

namespace Questions.Tests;


public class Question3Tests
{
    [Fact]
    public async Task SearchDirectory_ValidInputs_ReturnsExpectedResults()
    {
        // Arrange
        Question3 question3 = new Question3();
        string testDirectory = @".\TestFiles";
        string searchTerm = "widget";
        string filename = "TestResults.txt";

        // Act
        DirectorySearchResult result = await question3.SearchDirectory(testDirectory, searchTerm, filename);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.FilesProcessed);
        Assert.Equal(7, result.TotalLinesFound);
        Assert.Equal(8, result.TotalOccurrencesFound);
    }

    [Fact]
    public async Task SearchDirectory_NullDirectoryPath_ThrowsArgumentNullException()
    {
        // Arrange
        Question3 question3 = new Question3();
        string searchTerm = "test";
        string filename = "TestResults.txt";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => question3.SearchDirectory(null!, searchTerm, filename)); // null! is to suppress nullable warning
    }

    [Fact]
    public async Task SearchDirectory_EmptyDirectoryPath_ThrowsArgumentException()
    {
        // Arrange        
        Question3 question3 = new Question3();
        string searchTerm = "test";
        string filename = "TestResults.txt";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => question3.SearchDirectory(string.Empty, searchTerm, filename));
    }

    [Fact]
    public async Task SearchDirectory_NullSearchTerm_ThrowsArgumentNullException()
    {
        // Arrange
        Question3 question3 = new Question3();
        string testDirectory = @".\TestFiles";
        string filename = "TestResults.txt";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => question3.SearchDirectory(testDirectory, null!, filename)); // null! is to suppress nullable warning
    }

    [Fact]
    public async Task SearchDirectory_EmptySearchTerm_ThrowsArgumentException()
    {
        // Arrange
        var question3 = new Question3();
        string testDirectory = @".\TestFiles";
        string filename = "TestResults.txt";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => question3.SearchDirectory(testDirectory, string.Empty, filename));
    }

    [Fact]
    public async Task SearchDirectory_DirectoryNotFound_ThrowsDirectoryNotFoundException()
    {
        // Arrange
        var question3 = new Question3();
        string testDirectory = @".\TestFiles\NonExistentDirectory";
        string searchTerm = "widget";
        string filename = "TestResults.txt";

        // Act & Assert
        await Assert.ThrowsAsync<DirectoryNotFoundException>(() => question3.SearchDirectory(testDirectory, searchTerm, filename));
    }

    [Fact]
    public async Task SearchDirectory_NullFilename_ThrowsArgumentNullException()
    {
        // Arrange
        var question3 = new Question3();
        string testDirectory = @".\TestFiles";
        string searchTerm = "widget";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => question3.SearchDirectory(testDirectory, searchTerm, null!)); // null! is to suppress nullable warning
    }

    [Fact]
    public async Task SearchDirectory_EmptyFilename_ThrowsArgumentException()
    {
        // Arrange
        var question3 = new Question3();
        string testDirectory = @".\TestFiles";
        string searchTerm = "widget";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => question3.SearchDirectory(testDirectory, searchTerm, string.Empty));
    }   
}
