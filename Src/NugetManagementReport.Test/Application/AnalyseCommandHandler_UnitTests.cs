using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Application;
using NugetManagementReport.Domain;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Test.Application;

public class AnalyseCommandHandler_Handle
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_Analyse_CodeBase()
    {
        // Arrange
        var filePath = string.Empty;
        var mockConsoleWriter = new Mock<IConsoleWriter>();
        var mockPackageSourceFilePathValidator = new Mock<IPackageSourceFilePathValidator>();
        var mockFileProvider = new Mock<IFileProvider>();
        var mockPackageDependencyParsingService = new Mock<IPackageDependencyParsingService>();

        var validationResult = new ValidationResult();
        mockPackageSourceFilePathValidator.Setup(x => x.Validate(filePath)).Returns(validationResult);

        //mockPackageSourceFilePathValidator.Setup(x => x.(filePath)).Returns(validationResult);


        var services = new ServiceCollection();
        services.AddCommandHandlers();
        services.AddTransient(sp => mockConsoleWriter.Object);
        services.AddTransient(sp => mockPackageSourceFilePathValidator.Object);
        services.AddTransient(sp => mockFileProvider.Object);
        services.AddTransient(sp => mockPackageDependencyParsingService.Object);

        // Act
        services.BuildServiceProvider().GetRequiredService<IAnalyseCommandHandler>().Handle(filePath);

        // Assert 
        mockPackageDependencyParsingService.Verify(x => x.ReadNugetPackageInfo(It.IsAny<List<string>>(), It.IsAny<CancellationToken>()));
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_OutputErrorMessages_Given_AnInvalidFilePath()
    {
        // Arrange
        var filePath = string.Empty;
        var mockConsoleWriter = new Mock<IConsoleWriter>();
        var mockPackageSourceFilePathValidator = new Mock<IPackageSourceFilePathValidator>();
        var mockFileProvider = new Mock<IFileProvider>();
        var mockPackageDependencyParsingService = new Mock<IPackageDependencyParsingService>();

        var validationResult = new ValidationResult(new List<ValidationFailure>() { new ("filePath", "foo") });
        mockPackageSourceFilePathValidator.Setup(x => x.Validate(filePath)).Returns(validationResult);

        var services = new ServiceCollection();
        services.AddCommandHandlers();
        services.AddTransient(sp => mockConsoleWriter.Object);
        services.AddTransient(sp => mockPackageSourceFilePathValidator.Object);
        services.AddTransient(sp => mockFileProvider.Object);
        services.AddTransient(sp => mockPackageDependencyParsingService.Object);

        // Act
        services.BuildServiceProvider().GetRequiredService<IAnalyseCommandHandler>().Handle(filePath);

        // Assert 
        mockConsoleWriter.Verify(x => x.WriteLine(It.IsAny<string>()));
    }
}
