using System.ComponentModel;
using NugetManagementReport.Application;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.Commands;

public sealed class PrintReportCommand(IPrintReportCommandHandler printReportCommandHandler) : Command<PrintReportCommand.Settings>
{
    private readonly IPrintReportCommandHandler _printReportCommandHandler = printReportCommandHandler;

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-f|--file <FILEPATH>")]
        [Description("The person or thing to greet.")]
        [DefaultValue("World")]
        public string FilePath { get; set; } = string.Empty;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        _printReportCommandHandler.Handle(settings.FilePath);
        return 0;
    }
}
