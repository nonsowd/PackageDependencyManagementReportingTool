namespace NugetManagementReport.Infrastructure;

public interface IFileProvider
{
    List<string> ReadAllLines(string path);
}
internal class FileProvider : IFileProvider
{
    public List<string> ReadAllLines(string path)
    {
        throw new NotImplementedException();
    }
}
