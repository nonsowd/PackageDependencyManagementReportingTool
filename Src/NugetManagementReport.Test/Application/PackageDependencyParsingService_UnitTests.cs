using Microsoft.Extensions.DependencyInjection;
using NugetManagementReport.Application;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Test.Application;

public class PackageDependencyParsingService_ReadNugetPackageInfo
{
    [Fact]
    [Trait("Category", "UnitTest")]     
    public async Task Should_ReturnAListOfNugetPackage_Given_AListOfLinesInAProjectFileAsync()
    {
        // Arrange

        const string rawProjfiles = """
            <Project Sdk="Microsoft.NET.Sdk">

            <PropertyGroup>
                <OutputType>Exe</OutputType>
                <TargetFramework>net7.0</TargetFramework>
                <ImplicitUsings>enable</ImplicitUsings>
                <Nullable>enable</Nullable>
            </PropertyGroup>

            <ItemGroup>
                <PackageReference Include="FluentValidation" Version="11.9.0" />
            </ItemGroup>

            </Project>
            """;
        var lines = rawProjfiles.Split('\n').ToList();
     
        var cancellationToken = CancellationToken.None;
      
        //var mockConsoleWriter = new Mock<IConsoleWriter>();

        var services = new ServiceCollection();
        services.AddCommandHandlers();
        services.AddUI();
        //services.AddTransient(sp => mockConsoleWriter.Object);

        // Act
        var result = await services.BuildServiceProvider()
            .GetRequiredService<IPackageDependencyParsingService>()
            .ReadNugetPackageInfo(lines, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
 
        var expectedPackage = result.Single();
       
        expectedPackage.PackageName.Should().Be("FluentValidation");
        expectedPackage.PackageVersion.Should().Be("11.9.0");
        //mockConsoleWriter.Verify(x => x.WriteLine($"Hello {filePath}!"));
    }

    /*
     <Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>

    ==========

    <Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="FluentValidation" Version="11.9.0" />
  </ItemGroup>

</Project>

    ==============================
    <Project>
  <ItemGroup>
    <PackageVersion Include="FluentAssertions" Version="6.12.0" />
    <PackageVersion Include="FluentValidation" Version="11.9.0" />
    <PackageVersion Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
    <PackageVersion Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.0" />
    <PackageVersion Include="Microsoft.NET.Test.Sdk" Version="17.6.0" />
    <PackageVersion Include="Moq" Version="4.20.70" />
    <PackageVersion Include="PDFsharp" Version="6.0.0" />
  </ItemGroup>
</Project>

    ++++++

    <Project>
    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Product>Package Dependency Management Reporting Tool</Product>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
        <EnableNETAnalyzers>true</EnableNETAnalyzers>
        <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally><!--See: https://devblogs.microsoft.com/nuget/introducing-central-package-management/-->
        <NoWarn>$(NoWarn);</NoWarn><!--https://github.com/dotnet/aspnetcore/issues/50836-->
    </PropertyGroup>
</Project>

    ++++++

    <Project Sdk="Microsoft.NET.Sdk">

    <ItemGroup>
        <None Include="..\.editorconfig" Link=".editorconfig" />
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="..\NugetManagementReport.Domain\NugetManagementReport.Domain.csproj" />
        <ProjectReference Include="..\NugetManagementReport.Infrastructure\NugetManagementReport.Infrastructure.csproj" />
    </ItemGroup>

</Project>

    =====================================
        <Project>
  <ItemGroup>
    <PackageVersion Include="FluentAssertions" Version="6.12.0" />
    <PackageVersion Include="FluentValidation" Version="11.9.0" />
    <PackageVersion Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
    <PackageVersion Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.0" />
    <PackageVersion Include="Microsoft.NET.Test.Sdk" Version="17.6.0" />
    <PackageVersion Include="Moq" Version="4.20.70" />
    <PackageVersion Include="PDFsharp" Version="6.0.0" />
  </ItemGroup>
</Project>

    ++++++

    <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Product>Package Dependency Management Reporting Tool</Product>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
        <EnableNETAnalyzers>true</EnableNETAnalyzers>
        <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally><!--See: https://devblogs.microsoft.com/nuget/introducing-central-package-management/-->
        <NoWarn>$(NoWarn);</NoWarn><!--https://github.com/dotnet/aspnetcore/issues/50836-->
    </PropertyGroup>
    <ItemGroup>
        <None Include="..\.editorconfig" Link=".editorconfig" />
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="..\NugetManagementReport.Domain\NugetManagementReport.Domain.csproj" />
        <ProjectReference Include="..\NugetManagementReport.Infrastructure\NugetManagementReport.Infrastructure.csproj" />
    </ItemGroup>

</Project>


    */
}
