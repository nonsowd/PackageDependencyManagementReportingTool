using NugetManagementReport.Application;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using NugetManagementReport.Tool;
using NugetManagementReport.Tool.Commands;

// https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create
// https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-use
// https://spectreconsole.net/cli/introduction

var services = new ServiceCollection();
services.AddCommandHandlers();

// Create a type registrar and register any dependencies.
// A type registrar is an adapter for a DI framework.
var registrar = new TypeRegistrar(services);

// Create a new command app with the registrar
// and run it with the provided arguments.
var app = new CommandApp<DefaultCommand>(registrar);
app.Configure(cfg =>
{
    cfg.AddCommand<RunCommand>("Run");
});
return app.Run(args);


//var rootCommand = host.Services.GetRequiredService<RootCommand>();
//await rootCommand.InvokeAsync(args).ConfigureAwait(false);

//internal class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");

//        var filePath = args[0];
//        var runCommandHandler = new RunCommandHandler();
//        var runCommand = new RunCommand(runCommandHandler);
//        runCommand.Execute(filePath);

//        Console.ReadLine();

//       
//    }
//}
