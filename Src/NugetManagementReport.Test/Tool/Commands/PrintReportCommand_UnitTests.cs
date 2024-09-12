using NugetManagementReport.Application;
using NugetManagementReport.Tool.Commands;

namespace NugetManagementReport.Test.Tool.Commands;

public class PrintReportCommand_Excute
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_DelegateTo_PrintReportCommandHandler_Handle()
    {
        // Arrange
        var mockPrintReportCommandHandler = new Mock<IPrintReportCommandHandler>();
        var command = new PrintReportCommand(mockPrintReportCommandHandler.Object);
        var filePath = string.Empty;
        var settings = new PrintReportCommand.Settings { FilePath = filePath };

        // Act
        command.Execute(null!, settings);

        // Assert 
        mockPrintReportCommandHandler.Verify(x => x.Handle(filePath));
    }

}
