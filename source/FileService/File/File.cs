using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileService
{
    public sealed class File
    {
        public File()
        {
            Id = Guid.NewGuid();
        }

        public File
        (
            Guid id,
            string name,
            byte[] bytes
        )
        {
            Id = id;
            Name = name;
            Bytes = bytes;
        }

        public byte[] Bytes { get; set; }

        public string ContentType
        {
            get
            {
                new FileExtensionContentTypeProvider().TryGetContentType(Name, out var contentType);
                return contentType;
            }
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public string Subdirectory { get; set; }

        public static void Delete(string directory, Guid id)
        {
            var fileInfo = GetFileInfo(directory, id);

            if (fileInfo == null)
            {
                return;
            }

            System.IO.File.Delete(fileInfo.FullName);
        }

        public static async Task<File> GetAsync(string directory, Guid id)
        {
            var fileInfo = GetFileInfo(directory, id);

            if (fileInfo == null)
            {
                return null;
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(fileInfo.FullName);

            return new File(id, fileInfo.Name, bytes);
        }

        public static FileInfo GetFileInfo(string directory, Guid id)
        {
            return new DirectoryInfo(directory).GetFiles(string.Concat(id, ".*"), SearchOption.AllDirectories).SingleOrDefault();
        }

        public async Task SaveAsync(string directory)
        {
            if (!string.IsNullOrWhiteSpace(Subdirectory))
            {
                directory = Path.Combine(directory, Subdirectory);
            }

            Directory.CreateDirectory(directory);

            var name = string.Concat(Id, Path.GetExtension(Name));

            var path = Path.Combine(directory, name);

            await System.IO.File.WriteAllBytesAsync(path, Bytes);
        }
    }
}
