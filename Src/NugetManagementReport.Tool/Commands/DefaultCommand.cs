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
        public string Name { get; set; } = string.Empty;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        AnsiConsole.WriteLine($"Hello {settings.Name}! - version: {version}");
        return 0;
    }
}
