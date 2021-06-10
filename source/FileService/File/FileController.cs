using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileService
{
    [Route("files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpDelete("{id:Guid}")]
        public void Delete(Guid id)
        {
            _fileService.Delete(id);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var file = await _fileService.GetAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return File(file.Bytes, file.ContentType, file.Name);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(File file)
        {
            var result = await _fileService.SaveAsync(file);

            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
