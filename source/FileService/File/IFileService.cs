using System;
using System.Threading.Tasks;

namespace FileService
{
    public interface IFileService
    {
        void Delete(Guid id);

        Task<File> GetAsync(Guid id);

        Task<IResult<Guid>> SaveAsync(File file);
    }
}
