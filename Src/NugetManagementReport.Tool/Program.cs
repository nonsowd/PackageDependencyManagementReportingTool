using System.Reflection;
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
#if DEBUG
    cfg.PropagateExceptions();
    cfg.ValidateExamples();
#endif
    cfg.AddCommand<RunCommand>("Run");
    //cfg.AddCommand<AnalyseCommand>("Analyse")
    //    .WithAlias("analyse-dependencies")
    //    .WithDescription("Runs security vulnerablity and outdated check on nuget packages");
       //.WithExample(new[] { "size", "c:\\windows", "--pattern", "*.dll" });
});
return app.Run(args);


