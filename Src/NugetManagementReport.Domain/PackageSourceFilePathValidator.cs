using FluentValidation;
using NugetManagementReport.Infrastructure;

namespace NugetManagementReport.Domain;

public interface IPackageSourceFilePathValidator : IValidator<string>
{
    public const string FileDoesNotExistValidationMessage = "FilePath does not exist on disk";
}
internal class PackageSourceFilePathValidator : AbstractValidator<string>, IPackageSourceFilePathValidator
{
    private readonly IFileProvider _fileProvider;

    public PackageSourceFilePathValidator(IFileProvider fileProvider) 
    {
        ClassLevelCascadeMode = CascadeMode.Stop; // short circuit to return after first failure
        
        RuleFor(filePath => filePath).NotEmpty().OverridePropertyName("filePath");
        RuleFor(filepath => filepath).Must(BeAValidFilePath).WithMessage(IPackageSourceFilePathValidator.FileDoesNotExistValidationMessage);
        _fileProvider = fileProvider;
    }
    
    private bool BeAValidFilePath(string filePath) => _fileProvider.Exists(filePath);
}
