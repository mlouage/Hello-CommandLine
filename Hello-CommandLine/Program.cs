using Hello_CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;

var rootCommand = new ImporterRootCommand();
rootCommand.Description = Description();

var productsCommand = new ProductsCommand();
rootCommand.AddCommand(productsCommand);

var pricesCommand = new PricesCommand();
rootCommand.AddCommand(pricesCommand);

var commandLineBuilder = new CommandLineBuilder(rootCommand)
    .UseHost(host => 
    {
        host.ConfigureServices((context, services) =>
        {
            services.AddScoped<IReadFileService, ReadFileService>();
        })
        .UseCommandHandler<ProductsCommand, ProductsCommandHandler>()
        .UseCommandHandler<PricesCommand, ProductsCommandHandler>();
    })
    .UseDefaults();

var parser = commandLineBuilder.Build();

return await parser.InvokeAsync(args);

static string Description() => @"
 ___                            _
|_ _|_ __ ___  _ __   ___  _ __| |_ ___ _ __
 | || '_ ` _ \| '_ \ / _ \| '__| __/ _ | '__|
 | || | | | | | |_) | (_) | |  | ||  __| |
|___|_| |_| |_| .__/ \___/|_|   \__\___|_|
              |_|
";