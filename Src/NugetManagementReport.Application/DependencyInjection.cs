using NugetManagementReport.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddTransient<IRunCommandHandler, RunCommandHandler>();
        services.AddTransient<IAnalyseCommandHandler, AnalyseCommandHandler>();
        services.AddTransient<IPrintReportCommandHandler, PrintReportCommandHandler>();
        services.AddTransient<IProjectPlanCommandHandler, ProjectPlanCommandHandler>();
        services.AddTransient<IPackageDependencyParsingService, PackageDependencyParsingService>();

        return services;
    }
}
