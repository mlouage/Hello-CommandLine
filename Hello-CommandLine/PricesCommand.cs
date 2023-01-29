using System.CommandLine;

namespace Hello_CommandLine
{
    public class PricesCommand : Command
    {
        public PricesCommand() : base("prices", "Import prices from a file.")
        {
            var fileOption = new Option<FileInfo?>(
                name: "--file",
                description: "The file to import.");
            fileOption.IsRequired = true;

            AddOption(fileOption);
        }
    }
}
