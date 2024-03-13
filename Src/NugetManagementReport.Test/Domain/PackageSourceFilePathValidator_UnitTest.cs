using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Domain;

namespace NugetManagementReport.Test.Domain;

public class PackageSourceFilePathValidator_Validate
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnValid_Given_AValidFilePath()
    {
        // TODO: Expand filepath validator

        // Arrange
        var filePath = "string";

        var services = new ServiceCollection();
        services.AddDomain();

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

        var services = new ServiceCollection();
        services.AddDomain();

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains("must not be empty"));
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathOfWhiteSpace()
    {
        // Arrange
        var filePath = "   ";

        var services = new ServiceCollection();
        services.AddDomain();

        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains("must not be empty"));
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathThatDoesNotExist()
    {
        // Arrange
        var filePath = @"C:\Windows\Temp\AA8DE49B-9ED7-4B0B-8640-F7807D1D1CCA\doesNotExist.sln";

        var services = new ServiceCollection();
        services.AddDomain();
        
        // Act
        var result = services.BuildServiceProvider().GetRequiredService<IPackageSourceFilePathValidator>().Validate(filePath);

        // Assert 
        result.IsValid.Should().BeFalse();

        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().Contain(x => x.ErrorMessage.Contains(IPackageSourceFilePathValidator.FileDoesNotExistValidationMessage));
    }

    [Fact]
    [Trait("Category", "UnitTest")]
    public void Should_ReturnAValidationError_Given_AFilePathWithIncorrectExtention()
    {
        Assert.Fail("Test not Implemented");
    }
}
