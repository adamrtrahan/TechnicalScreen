using System.Text.RegularExpressions;
using Questions.models;

namespace Questions;

public class Question3
{
    public Question3()
    {
    }

    public async Task<DirectorySearchResult> SearchDirectory(string directoryPath, string searchTerm, string filename)
    {
        ValidateParameters(directoryPath, searchTerm, filename);

        string[] files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.TopDirectoryOnly); //could search subdirectories, simplifying so results aren't included in search

        List<Task<FileSearchResult>> fileSearchTasks = new();

        foreach (string file in files)
        {
            fileSearchTasks.Add(SearchFile(file, searchTerm));
        }

        //using these results objects to avoid concurrency issues with multiple threads writing to the same object
        FileSearchResult[] fileSearchResults = await Task.WhenAll(fileSearchTasks);

        await WriteFileSearchResuts(fileSearchResults, directoryPath, filename);

        return new DirectorySearchResult(fileSearchResults);
    }

    private async Task WriteFileSearchResuts(FileSearchResult[] fileSearchResults, string directoryPath, string filename)
    {
        const string outputFolderName = "SearchResults";
        IEnumerable<string> lines = fileSearchResults.SelectMany(x => x.Lines);

        //Ensure the output directory exists
        string outputDirectory = Path.Combine(directoryPath, outputFolderName);
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        //create the file in a nested output directory so it doesn't get picked up in future searches
        string outputFilePath = Path.Combine($"{outputDirectory}", filename);
        await File.WriteAllLinesAsync(outputFilePath, lines);
    }

    private async Task<FileSearchResult> SearchFile(string fileName, string searchTerm)
    {
        string[] lines = File.ReadAllLines(fileName);

        List<Task<LineSearchResult>> lineSearchTasks = new();

        foreach (string line in lines)
        {
            lineSearchTasks.Add(SearchLine(line, searchTerm));
        }

        return new FileSearchResult(await Task.WhenAll(lineSearchTasks));
    }

    private async Task<LineSearchResult> SearchLine(string line, string searchTerm)
    {
        LineSearchResult result = new();

        result.TotalOccurrencesFound = await Task.Run(() => CountOccurrences(line, searchTerm));
        result.IsFound = result.TotalOccurrencesFound > 0;
        result.Line = result.IsFound ? line : null;

        return result;
    }

    private int CountOccurrences(string line, string searchTerm)
    {
        string pattern = Regex.Escape(searchTerm);
        return Regex.Matches(line, pattern).Count;
    }
    
    private void ValidateParameters(string directoryPath, string searchTerm, string filename)
    {
        //Id probalby would use a validation library in a real world scenario
        if (directoryPath == null)
        {
            throw new ArgumentNullException($"{nameof(directoryPath)} cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(directoryPath))
        {
            throw new ArgumentException($"{nameof(directoryPath)} cannot be empty.");
        }

        if (searchTerm == null)
        {
            throw new ArgumentNullException($"{nameof(searchTerm)} cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            throw new ArgumentException($"{nameof(searchTerm)} cannot be empty.");
        }

        if (filename == null)
        {
            throw new ArgumentNullException($"{nameof(filename)} cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(filename))
        {
            throw new ArgumentException($"{nameof(filename)} cannot be empty.");
        }

        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"The directory '{directoryPath}' does not exist.");
        }
    }
}