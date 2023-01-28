using Hello_CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;

var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to import.");
fileOption.IsRequired = true;

var rootCommand = new RootCommand();
rootCommand.Description = Description();

var productsCommand = new Command("products", "Import products from a file.")
{
    fileOption
};

var pricesCommand = new Command("prices", "Import prices from a file.")
{
    fileOption
};

rootCommand.AddCommand(productsCommand);
rootCommand.AddCommand(pricesCommand);


productsCommand.SetHandler((file) =>
{
    ReadFile(file!);
}, fileOption);

pricesCommand.SetHandler((file) =>
{
    ReadFile(file!);
}, fileOption);

var commandLineBuilder = new CommandLineBuilder(rootCommand)
    .UseHost(host => 
    {
        host.ConfigureServices((context, services) =>
        {
            services.AddScoped<IMyService, MyService>();
        });
     })
    .UseDefaults();

var parser = commandLineBuilder.Build();

return await parser.InvokeAsync(args);

static void ReadFile(FileInfo file)
{
    File.ReadLines(file.FullName).ToList()
        .ForEach(line => Console.WriteLine(line));
}

static string Description() => @"
 ___                            _
|_ _|_ __ ___  _ __   ___  _ __| |_ ___ _ __
 | || '_ ` _ \| '_ \ / _ \| '__| __/ _ | '__|
 | || | | | | | |_) | (_) | |  | ||  __| |
|___|_| |_| |_| .__/ \___/|_|   \__\___|_|
              |_|
";