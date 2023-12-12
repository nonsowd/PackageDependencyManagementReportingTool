using NugetManagementReport.Domain;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Application;
public interface IPackageDependencyParsingService
{
    List<NugetPackage> ReadNugetPackageInfo (string path);
}
internal class PackageDependencyParsingService: IPackageDependencyParsingService
{
    private readonly IFileProvider _fileProvider;

    public PackageDependencyParsingService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    public List<NugetPackage> ReadNugetPackageInfo(string path)
    {
        var line = _fileProvider.ReadAllLines(path);    
        throw new NotImplementedException();
    }
}



