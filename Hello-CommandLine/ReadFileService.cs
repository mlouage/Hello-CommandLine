namespace Hello_CommandLine;

public class ReadFileService : IReadFileService
{
    public async Task ReadFileAsync(FileInfo fileInfo)
    {
        var lines = await File.ReadAllTextAsync(fileInfo.FullName);
        Console.WriteLine(lines);
    }
}
