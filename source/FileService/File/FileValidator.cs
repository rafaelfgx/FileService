using FluentValidation;
using System.IO;

namespace FileService
{
    public sealed class FileValidator : AbstractValidator<File>
    {
        public FileValidator()
        {
            RuleFor(file => file.Name).Must(Name);
            RuleFor(file => file.Bytes).NotEmpty();
            RuleFor(file => file.Subdirectory).Must(Subdirectory).When(HasSubdirectory);
        }

        private static bool HasSubdirectory(File file)
        {
            return !string.IsNullOrWhiteSpace(file.Subdirectory);
        }

        private static bool Name(string name)
        {
            return Path.HasExtension(name) && name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 && !name.StartsWith('.');
        }

        private static bool Subdirectory(string path)
        {
            return
                !string.IsNullOrWhiteSpace(path) &&
                !Path.IsPathRooted(path) &&
                !Path.HasExtension(path) &&
                !Path.EndsInDirectorySeparator(path) &&
                !path.Contains('.') &&
                path.IndexOfAny(Path.GetInvalidPathChars()) < 0 &&
                ((Path.DirectorySeparatorChar == '\\' && !path.Contains('/')) || (Path.DirectorySeparatorChar == '/' && !path.Contains('\\')));
        }
    }
}
