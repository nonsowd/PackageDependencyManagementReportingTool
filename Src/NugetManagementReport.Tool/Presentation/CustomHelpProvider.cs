using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Help;
using Spectre.Console.Rendering;

internal class CustomHelpProvider(ICommandAppSettings settings) : HelpProvider(settings)
{
    public override IEnumerable<IRenderable> GetHeader(ICommandModel model, ICommandInfo? command)
    {
        if (command is { IsDefaultCommand: false }) // Skip for command specific help.
            return base.GetHeader(model, command);

        return new IRenderable[] // otherwise show header.
        {
            new FigletText("NuGet Report").LeftJustified().Color(Color.Blue), Text.NewLine,
            new Text($"NuGet Report Command Line Tool V{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}"), Text.NewLine,
            Text.NewLine,
        };
    }
}
