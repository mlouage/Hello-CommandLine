namespace Hello_CommandLine
{
    public interface IReadFileService
    {
        Task ReadFileAsync(FileInfo fileInfo);
    }
}