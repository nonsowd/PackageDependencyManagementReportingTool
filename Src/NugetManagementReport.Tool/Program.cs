using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Infrastructure;
using NugetManagementReport.Tool.Commands;
using NugetManagementReport.Tool.Presentation;
using NugetManagementReport.Tool.TypeResolution;
using Spectre.Console.Cli;

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
app.Configure(cfg => cfg.AddCommand<RunCommand>("Run"));
return app.Run(args);
