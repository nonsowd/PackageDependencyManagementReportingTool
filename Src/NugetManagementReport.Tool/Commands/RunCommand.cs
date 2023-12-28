using System.ComponentModel;
using NugetManagementReport.Application;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.Commands;

public sealed class RunCommand : Command<RunCommand.Settings>
{
    private IRunCommandHandler _runCommandHandler;

    public RunCommand(IRunCommandHandler runCommandHandler)
    {
        _runCommandHandler = runCommandHandler;
    }

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-f|--file <FILEPATH>")]
        [Description("The person or thing to greet.")]
        [DefaultValue("World")]
        public string FilePath { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        _runCommandHandler.Handle(settings.FilePath);
        return 0;
    }
}
