using System.ComponentModel;
using NugetManagementReport.Application;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.Commands;

public sealed class AnalyseCommand(IAnalyseCommandHandler analyseCommandHandler) : Command<AnalyseCommand.Settings>
{
    private readonly IAnalyseCommandHandler _analyseCommandHandler = analyseCommandHandler;

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-f|--file <FILEPATH>")]
        [Description("The person or thing to greet.")]
        [DefaultValue("World")]
        public string FilePath { get; set; } = string.Empty;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        _analyseCommandHandler.Handle(settings.FilePath);
        return 0;
    }
}
