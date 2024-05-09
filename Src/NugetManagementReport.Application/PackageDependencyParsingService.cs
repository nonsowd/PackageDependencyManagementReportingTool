using System.Xml.Linq;
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
        if (lines.Any(line => line.Contains("PackageReference")) == false)
        {
            return new List<NugetPackage>();
        }

        // TODO: Handle when line are NOT valid XML
        var doc = XDocument.Parse(string.Concat(lines));
        var elements = doc.Descendants().Where(x => x.Name.LocalName == "PackageReference").ToList();
        var result = new List<NugetPackage>();

        foreach ( var element in elements )
        {
            result.Add(ParseNugetPackage(element));
        }
        return result;
    }

    private NugetPackage ParseNugetPackage (XElement element)
        => new NugetPackage()
        {
            PackageName = element.Attributes().Single(x => x.Name == "Include").Value,
            PackageVersion = element.Attributes().Single(x => x.Name == "Version").Value
        };
}
