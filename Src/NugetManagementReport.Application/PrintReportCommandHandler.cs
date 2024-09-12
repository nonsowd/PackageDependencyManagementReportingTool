namespace NugetManagementReport.Application;

public interface IPrintReportCommandHandler
{
    void Handle(string filePath);
}
internal class PrintReportCommandHandler : IPrintReportCommandHandler
{
    public void Handle(string filePath) => throw new NotImplementedException();
}
