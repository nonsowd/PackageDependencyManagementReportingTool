namespace NugetManagementReport.Infrastructure;

public interface IFileProvider
{
    bool Exists(string filePath);
    Task<List<string>> ReadAllLinesAsync(string path, CancellationToken cancellationToken);
}
internal class FileProvider : IFileProvider
{
    public bool Exists(string filePath) => File.Exists(filePath);

    public async Task<List<string>> ReadAllLinesAsync(string path, CancellationToken cancellationToken)
    {
        var lines = await File.ReadAllLinesAsync(path, cancellationToken);
        return new List<string>(lines);
    }
}
