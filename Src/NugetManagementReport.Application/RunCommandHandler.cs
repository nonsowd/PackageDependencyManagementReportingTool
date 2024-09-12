using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Application;

public interface IRunCommandHandler
{
    void Handle(string filePath);
}
internal class RunCommandHandler(IConsoleWriter console) : IRunCommandHandler
{
    private readonly IConsoleWriter _console = console;

    public void Handle(string filePath)
        => _console.WriteLine($"Hello {filePath}!");
} 
