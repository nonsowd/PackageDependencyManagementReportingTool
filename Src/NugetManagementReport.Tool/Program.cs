using NugetManagementReport.Application;

namespace NugetManagementReport.Tool;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var filePath = args[0];
        var runCommandHandler = new RunCommandHandler();
        var runCommand = new RunCommand(runCommandHandler);
        runCommand.Execute(filePath);

        Console.ReadLine();
    }
}
