using System.CommandLine;

namespace Hello_CommandLine
{
    public class ProductsCommand : Command
    {
        public ProductsCommand() : base("products", "Import products from a file.")
        {
            var fileOption = new Option<FileInfo?>(
                name: "--file",
                description: "The file to import.");
            fileOption.IsRequired = true;

            AddOption(fileOption);
        }
    }
}
