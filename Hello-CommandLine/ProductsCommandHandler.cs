using System.CommandLine;
using System.CommandLine.Invocation;

namespace Hello_CommandLine;

public class ProductsCommandHandler : ICommandHandler
{
    private readonly IReadFileService _readFileService;
    private Option<FileInfo>? _fileOption;

    public ProductsCommandHandler(IReadFileService readFileService)
    {
        _readFileService = readFileService;
    }

    public int Invoke(InvocationContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InvokeAsync(InvocationContext context)
    {
        _fileOption = context.ParseResult.CommandResult.Command.Options.First(o => o.Name.ToLowerInvariant().Equals("file")) as Option<FileInfo>;
        var fileInfo = context.ParseResult.GetValueForOption(_fileOption!);

        await _readFileService.ReadFileAsync(fileInfo!);

        return 0;
    }
}
