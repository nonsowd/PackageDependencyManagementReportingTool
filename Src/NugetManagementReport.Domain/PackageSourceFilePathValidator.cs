using FluentValidation;

namespace NugetManagementReport.Domain;

public interface IPackageSourceFilePathValidator : IValidator<string>
{
    public const string FileDoesNotExistValidationMessage = "FilePath does not exist on disk";
}
internal class PackageSourceFilePathValidator : AbstractValidator<string>, IPackageSourceFilePathValidator
{
    public PackageSourceFilePathValidator()
    {
        RuleFor(filePath => filePath).NotEmpty().OverridePropertyName("filePath");
        RuleFor(filepath => filepath).Must(BeAValidFilePath).WithMessage(IPackageSourceFilePathValidator.FileDoesNotExistValidationMessage);
    }

    private bool BeAValidFilePath(string filePath)
    {
        return File.Exists(filePath);

    }
}
