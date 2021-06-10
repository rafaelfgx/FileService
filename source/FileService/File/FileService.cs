using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileService
{
    public sealed class FileService : IFileService
    {
        private readonly AppSettings _appSettings;

        public FileService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Delete(Guid id)
        {
            File.Delete(_appSettings.Directory, id);
        }

        public Task<File> GetAsync(Guid id)
        {
            return File.GetAsync(_appSettings.Directory, id);
        }

        public async Task<IResult<Guid>> SaveAsync(File file)
        {
            var validation = await ValidateAsync(file);

            if (!validation.Succeeded)
            {
                return Result<Guid>.Fail(validation.Message);
            }

            await file.SaveAsync(_appSettings.Directory);

            return Result<Guid>.Success(file.Id);
        }

        private static IResult GetResult(ValidationResult result)
        {
            return result.IsValid ? Result.Success() : Result.Fail(result.ToString());
        }

        private static async Task<IResult> ValidateAsync(File file)
        {
            return GetResult(await new FileValidator().ValidateAsync(file));
        }
    }
}
