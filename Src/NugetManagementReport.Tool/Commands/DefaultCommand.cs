using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.Commands;

public sealed class DefaultCommand : Command<DefaultCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-n|--name <NAME>")]
        [Description("The person or thing to greet.")]
        [DefaultValue("World")]
        public string Name { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine($"Hello {settings.Name}!");
        return 0;
    }
}
