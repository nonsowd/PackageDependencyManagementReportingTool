namespace NugetManagementReport.Application;

public interface IProjectPlanCommandHandler
{
    void Handle(string filePath);
}
internal class ProjectPlanCommandHandler : IProjectPlanCommandHandler
{
    public void Handle(string filePath) => throw new NotImplementedException();
}
