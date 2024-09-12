using NugetManagementReport.Application;
using NugetManagementReport.Tool.Commands;

namespace NugetManagementReport.Test.Tool.Commands;

public class ProjectPlanCommand_Execute
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_DelegateTo_ProjectPlanCommandHandler_Handle()
    {
        // Arrange
        var mockProjectPlanCommandHandler = new Mock<IProjectPlanCommandHandler>();
        var command = new ProjectPlanCommand(mockProjectPlanCommandHandler.Object);
        var filePath = string.Empty;
        var settings = new ProjectPlanCommand.Settings { FilePath = filePath };

        // Act
        command.Execute(null!, settings);

        // Assert 
        mockProjectPlanCommandHandler.Verify(x => x.Handle(filePath));
    }
}
