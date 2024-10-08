using System.ComponentModel;
using NugetManagementReport.Application;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.Commands;

public sealed class RunCommand(IRunCommandHandler runCommandHandler) : Command<RunCommand.Settings>
{
    private readonly IRunCommandHandler _runCommandHandler = runCommandHandler;

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-f|--file <FILEPATH>")]
        [Description("The person or thing to greet.")]
        [DefaultValue("World")]
        public string FilePath { get; set; } = string.Empty;  
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        _runCommandHandler.Handle(settings.FilePath);
        return 0;
    }
}
