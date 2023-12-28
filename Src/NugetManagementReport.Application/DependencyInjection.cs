

using NugetManagementReport.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddTransient<IRunCommandHandler, RunCommandHandler>();
        return services;
    }
}
