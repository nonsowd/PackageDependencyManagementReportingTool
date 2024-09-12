using NugetManagementReport.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IFileProvider, FileProvider>();

        return services;
    }
}
