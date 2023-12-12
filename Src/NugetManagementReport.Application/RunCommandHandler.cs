using System.Security.Cryptography.X509Certificates;

namespace NugetManagementReport.Application;

public interface IRunCommandHandler
{
    void Handle(string filePath);
}
public class RunCommandHandler : IRunCommandHandler
{
    public void Handle(string filePath)
    {
        // TODO: Implement RunCommandHandler
    }
} 
