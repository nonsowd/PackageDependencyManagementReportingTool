using System.Text.Json;
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
    private readonly IFileProvider _fileProvider;
    private readonly IPackageDependencyParsingService _packageDependencyParsingService;

    public AnalyseCommandHandler (
        IConsoleWriter console,
        IPackageSourceFilePathValidator packageSourceFilePathValidator,
        IFileProvider fileProvider,
        IPackageDependencyParsingService packageDependencyParsingService)
    {
        _console = console;
        _packageSourceFilePathValidator = packageSourceFilePathValidator;
        _fileProvider = fileProvider;
        _packageDependencyParsingService = packageDependencyParsingService;
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

        var result = _packageSourceFilePathValidator.Validate(filePath);

        // check for validation error with IPackageSourceFilePathValidator
        if (result.IsValid == false) 
        {
            // Write error to screen
            foreach (var item in result.Errors)
            {
                _console.WriteLine(item.ErrorMessage);
            }
            return;
        }

        //var lines = _fileProvider.ReadAllLinesAsync(filePath);
        // TODO: cascade Async CancellationToken
        var packages = _packageDependencyParsingService.ReadNugetPackageInfo([], CancellationToken.None);

        //var outputJson = JsonSerializer.Serialize(packages);

        //_fileProvider.WriteAllLinesAsync(outputFilePath);

    }
}
