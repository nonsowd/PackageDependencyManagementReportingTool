using NugetManagementReport.Domain;

namespace NugetManagementReport.Application;
public interface IPackageDependencyParsingService
{
    Task<List<NugetPackage>> ReadNugetPackageInfo(List<string> lines, CancellationToken cancellationToken);
}
internal class PackageDependencyParsingService : IPackageDependencyParsingService
{
    public async Task<List<NugetPackage>> ReadNugetPackageInfo(List<string> lines, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
