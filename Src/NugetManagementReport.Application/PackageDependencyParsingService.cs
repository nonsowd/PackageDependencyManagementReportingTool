using System.Reflection.Metadata.Ecma335;
using NugetManagementReport.Domain;

namespace NugetManagementReport.Application;
public interface IPackageDependencyParsingService
{
    Task<List<NugetPackage>> ReadNugetPackageInfo(List<string> lines, CancellationToken cancellationToken);
}
internal class PackageDependencyParsingService : IPackageDependencyParsingService
{
    public async Task<List<NugetPackage>> ReadNugetPackageInfo(List<string> lines, CancellationToken cancellationToken)
    {
   
        //if (lines.Any(line => line.Contains("PackageReference")) == false)
        //{
        //    return new List<NugetPackage>();
        //}

        var result = new List<NugetPackage>()
        {
            new NugetPackage()
            {

                //PackageName ="FluentValidation",
                //PackageVersion = "11.9.0"a5


            }
        };
        return result;
    }
}
