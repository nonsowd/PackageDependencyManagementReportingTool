using NugetManagementReport.Domain;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Application;

public interface IAnalyseCommandHandler
{
    void Handle(string filePath);
}
internal class AnalyseCommandHandler : IAnalyseCommandHandler
{
    private readonly IConsoleWriter _console;
    private readonly IPackageSourceFilePathValidator _packageSourceFilePathValidator;

    public AnalyseCommandHandler (IConsoleWriter console, IPackageSourceFilePathValidator packageSourceFilePathValidator)
    {
        _console = console;
        _packageSourceFilePathValidator = packageSourceFilePathValidator;
    }

    /*
    .Net Framework Dependency Analysis #2

    As a DevOps engineer,
    I want to run an analysis of outdated and vulnerable dependent NuGet packages in our legacy .Net Framework during an overnight
    build of our legacy .Net Framework codebase,
    so I can keep our codebase up to date and secure.

    .Net Core Dependency Analysis #1

    As a DevOps engineer,
    I want to run an analysis of outdated and vulnerable dependent NuGet packages during an overnight build of our .Net core codebase,
    so I can keep our codebase up to date and secure.
     */

    public void Handle(string filePath)
    {
        // Are we .Net Framwork or .Net Core?
        // Is filePath a .sln file or a directory.packages.props file?
        // (valid filePath to directory.packages.props) C:\Source\GitHub\nonsowd\PackageDependencyManagementReportingTool\Src\Directory.Packages.props

        _packageSourceFilePathValidator.Validate(filePath);
        throw new NotImplementedException();
    }
}
