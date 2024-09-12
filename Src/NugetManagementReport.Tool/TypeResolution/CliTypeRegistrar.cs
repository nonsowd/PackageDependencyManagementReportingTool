using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace NugetManagementReport.Tool.TypeResolution;

public sealed class CliTypeRegistrar(IServiceCollection builder) : ITypeRegistrar
{
    private readonly IServiceCollection _builder = builder;

    public ITypeResolver Build()
        => new TypeResolver(_builder.BuildServiceProvider());

    public void Register(Type service, Type implementation)
        => _builder.AddSingleton(service, implementation);

    public void RegisterInstance(Type service, object implementation)
        => _builder.AddSingleton(service, implementation);

    public void RegisterLazy(Type service, Func<object> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        _builder.AddSingleton(service, (provider) => func());
    }
}
