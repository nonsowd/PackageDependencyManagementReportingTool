using NugetManagementReport.Application;
using NugetManagementReport.Tool.Commands;

namespace NugetManagementReport.Test.Tool.Commands;

public class AnalyseCommand_Excute
{
    [Fact]
    [Trait("Category", "UnitTest")]

    public void Should_DelegateTo_AnalyseCommandHandler_Handle()
    {
        // Arrange
        var mockAnalyseCommandHandler = new Mock<IAnalyseCommandHandler>();
        var command = new AnalyseCommand(mockAnalyseCommandHandler.Object);
        var filePath = string.Empty;
        var settings = new AnalyseCommand.Settings { FilePath = filePath };

        // Act
        command.Execute(null!, settings);

        // Assert 
        mockAnalyseCommandHandler.Verify(x => x.Handle(filePath));
    }

}
