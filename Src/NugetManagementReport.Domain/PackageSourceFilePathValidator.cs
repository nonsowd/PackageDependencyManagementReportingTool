using FluentValidation;

namespace NugetManagementReport.Domain;

public interface IPackageSourceFilePathValidator : IValidator<string>
{
}
public class PackageSourceFilePathValidator : AbstractValidator<string>, IPackageSourceFilePathValidator
{
    public PackageSourceFilePathValidator()
        => RuleFor(filePath => filePath).NotEmpty().OverridePropertyName("filepath");
}
