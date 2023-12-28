using NugetManagementReport.Application;
using NugetManagementReport.Tool.Commands;

namespace NugetManagementReport.Test.UI;

public class RunCommand_Excute
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_DelegateTo_RunCommandHandler_Handle()
    {
        // Arrange
        var mockRunCommandHandler = new Mock<IRunCommandHandler>();
        var runCommand = new RunCommand(mockRunCommandHandler.Object);
        var filePath = string.Empty;
        var settings = new RunCommand.Settings { FilePath = filePath };

        // Act
        runCommand.Execute(null!, settings);

        // Assert 
        mockRunCommandHandler.Verify(x => x.Handle(filePath));
    }
}
