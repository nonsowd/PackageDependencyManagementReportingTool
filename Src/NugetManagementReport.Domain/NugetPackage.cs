namespace NugetManagementReport.Domain;

public record NugetPackage
{
    public string PackageName { get; set; } = string.Empty;
    public string PackageVersion { get; set; } = string.Empty;
}
