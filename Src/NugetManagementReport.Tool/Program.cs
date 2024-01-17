using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Infrastructure;
using NugetManagementReport.Tool.Commands;
using NugetManagementReport.Tool.Presentation;
using NugetManagementReport.Tool.TypeResolution;
using Spectre.Console.Cli;

//[assembly: AssemblyVersion("1.0.*")]

// https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create
// https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-use
// https://spectreconsole.net/cli/introduction

var services = new ServiceCollection();
services.AddCommandHandlers();
services.AddTransient<IConsoleWriter, CliConsole>();

// Create a type registrar and register any dependencies.
// A type registrar is an adapter for a DI framework.
var registrar = new CliTypeRegistrar(services);

// Create a new command app with the registrar
// and run it with the provided arguments.
var app = new CommandApp<DefaultCommand>(registrar);

app.Configure(cfg =>
{
    cfg.SetApplicationName("NuGetReport"); // Dotnet Global tool name here to get help to command match.
    cfg.CaseSensitivity(CaseSensitivity.None);
    cfg.SetHelpProvider(new CustomHelpProvider(cfg.Settings));
#if DEBUG
    cfg.PropagateExceptions();
    cfg.ValidateExamples();
#endif
    cfg.AddCommand<RunCommand>("run");
    cfg.AddCommand<AnalyseCommand>("analyse").WithAlias("analyse-dependencies")
        .WithDescription("Runs security vulnerability and outdated check on nuget packages");
    //.WithExample(new[] { "size", "c:\\windows", "--pattern", "*.dll" });
    cfg.AddCommand<PrintReportCommand>("report").WithAlias("print-report")
        .WithDescription("Produces a report of NuGet packages with security vulnerabilities or that are outdated.");
    cfg.AddCommand<ProjectPlanCommand>("project").WithAlias("project-plan")
        .WithDescription("Produces a csv file of work actions to resolve NuGet packages with security vulnerabilities or that are outdated.");
});
return app.Run(args);


