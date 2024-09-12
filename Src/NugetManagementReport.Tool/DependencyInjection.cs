using NugetManagementReport.Infrastructure;
using NugetManagementReport.Tool.Presentation;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddUI(this IServiceCollection services)
    {
        services.AddTransient<IConsoleWriter, CliConsole>();

        return services;
    }
}
