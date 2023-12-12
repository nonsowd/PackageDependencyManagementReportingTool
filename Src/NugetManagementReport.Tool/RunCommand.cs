using NugetManagementReport.Application;

namespace NugetManagementReport.Tool;

public class RunCommand
{
    private RunCommandHandler @object;

    public RunCommand(RunCommandHandler @object)
    {
        this.@object = @object;
    }

    public void Execute(string filePath)
    {
        @object.Handle(filePath);
    }
}
