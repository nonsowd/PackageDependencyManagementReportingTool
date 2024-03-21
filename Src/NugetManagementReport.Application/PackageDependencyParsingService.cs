using NugetManagementReport.Domain;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Application;
public interface IPackageDependencyParsingService
{
    Task<List<NugetPackage>> ReadNugetPackageInfo (string path, CancellationToken cancellationToken);
}
internal class PackageDependencyParsingService(IFileProvider fileProvider) : IPackageDependencyParsingService
{
    private readonly IFileProvider _fileProvider = fileProvider;

    public async Task<List<NugetPackage>> ReadNugetPackageInfo(string path, CancellationToken cancellationToken)
    {
        var line = await _fileProvider.ReadAllLinesAsync(path, cancellationToken);

        if (cancellationToken.IsCancellationRequested)
            return [];
        
        throw new NotImplementedException();
    }
}
