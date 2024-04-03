using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Domain;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Test.Domain;

public class PackageSourceFilePathValidator_Validate
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnValid_Given_AValidFilePath()
    {
        // Arrange
        var filePath = "string";
        var mockFileProvider = new Mock<IFileProvider>();
        mockFileProvider.Setup(x=>x.Exists(filePath)).Returns(true);

        var services = new ServiceCollection();
        services.AddDomain();
        services.AddTransient(sp => mockFileProvider.Object);

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathOfEmptyString()
    {
        // Arrange
        var filePath = string.Empty;
        var mockFileProvider = new Mock<IFileProvider>();

        var services = new ServiceCollection();
        services.AddDomain();
        services.AddTransient(sp => mockFileProvider.Object);

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();
  
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains("must not be empty"));

        mockFileProvider.Verify(x => x.Exists(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathOfWhiteSpace()
    {
        // Arrange
        var filePath = "   ";
        var mockFileProvider = new Mock<IFileProvider>();

        var services = new ServiceCollection();
        services.AddDomain();
        services.AddTransient(sp => mockFileProvider.Object);

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains("must not be empty"));

        mockFileProvider.Verify(x => x.Exists(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathThatDoesNotExist()
    {
        // Arrange
        var filePath = @"C:\Windows\Temp\AA8DE49B-9ED7-4B0B-8640-F7807D1D1CCA\doesNotExist.sln";
        var mockFileProvider = new Mock<IFileProvider>();
        mockFileProvider.Setup(x => x.Exists(filePath)).Returns(false);

        var services = new ServiceCollection();
        services.AddDomain();
        services.AddTransient(sp => mockFileProvider.Object);

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains(IPackageSourceFilePathValidator.FileDoesNotExistValidationMessage));

        mockFileProvider.Verify(x => x.Exists(filePath), Times.Once);
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathWithIncorrectExtention()
    {
        Assert.Fail("Test not Implemented");
    }
}
