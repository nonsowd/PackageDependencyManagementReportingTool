using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Application;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Test.Application;

public class RunCommandHandler_Handle
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_DelegateTo_RunCommandHandler_Handle()
    {
        // Arrange
        var filePath = string.Empty;
        var mockConsoleWriter = new Mock<IConsoleWriter>();

        var services = new ServiceCollection();
        services.AddCommandHandlers();
        services.AddTransient(sp => mockConsoleWriter.Object);

        // Act
        services.BuildServiceProvider().GetRequiredService<IRunCommandHandler>().Handle(filePath);

        // Assert 
        mockConsoleWriter.Verify(x => x.WriteLine($"Hello {filePath}!"));
    }
}
