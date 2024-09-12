using NugetManagementReport.Domain;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IPackageSourceFilePathValidator, PackageSourceFilePathValidator>();

        return services;
    }
}
