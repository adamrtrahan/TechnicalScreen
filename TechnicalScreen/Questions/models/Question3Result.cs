namespace Questions.models;

public class DirectorySearchResult
{
    public DirectorySearchResult(FileSearchResult[] fileSearchResults)
    {
        FilesProcessed = fileSearchResults.Length;
        TotalLinesFound = fileSearchResults.Sum(fsr => fsr.TotalLinesFound);
        TotalOccurrencesFound = fileSearchResults.Sum(fsr => fsr.TotalOccurrencesFound);
    }

    public int FilesProcessed { get; set; }
    public int TotalLinesFound { get; set; }
    public int TotalOccurrencesFound { get; set; }
}

public class FileSearchResult
{
    public FileSearchResult(LineSearchResult[] lineSearchResults)
    {
        TotalLinesFound = lineSearchResults.Count(lsr => lsr.IsFound);
        TotalOccurrencesFound = lineSearchResults.Sum(lsr => lsr.TotalOccurrencesFound);
        Lines = lineSearchResults.Where(lsr => lsr.IsFound).Select(lsr => lsr.Line!).ToArray();
    }

    public int TotalLinesFound { get; set; }
    public int TotalOccurrencesFound { get; set; }
    public string[] Lines { get; set; }
}

public class LineSearchResult
{
    public int TotalOccurrencesFound { get; set; }
    public bool IsFound { get; set; }
    public string? Line { get; set; }
}