using QuestPDF;
using Spectre.Console;

namespace NugetManagementReport.Application;

public interface IRunCommandHandler
{
    void Handle(string filePath);
}
internal class RunCommandHandler : IRunCommandHandler
{
    public void Handle(string filePath)
    {
        AnsiConsole.WriteLine($"Hello {filePath}!");
    }
} 
