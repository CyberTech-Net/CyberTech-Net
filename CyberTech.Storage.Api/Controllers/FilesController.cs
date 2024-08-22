using CyberTech.Storage.Api.Dto;
using CyberTech.Storage.Core.Abstractions.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberTech.Storage.Api.Controllers
{
    [Route("api/storage")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFile(string id)
        {
            try
            {
                var fileStream = await _fileService.GetFileAsync(id);
                var file = await _fileService.GetFileInfoAsync(id);
                var fileExtention = Path.GetExtension(file.Filename);
                return File(fileStream, $"application/{fileExtention}", file.Filename);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetListOfFiles()
        {
            var files = await _fileService.GetAllFiles();
            var response = files.Select(x => new FilesResponse()
            {
                FileId = x.Id.ToString(),
                FileName = x.Filename
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            var id = await _fileService.UploadFileAsync(file);
            var data = new { fileId = id.ToString() }; 
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            try
            {
                var file = await _fileService.GetFileInfoAsync(id);
                await _fileService.DeleteFile(id);
                var data = new { answer = $"{file.Filename} has been deleted successfully" };
                return Ok(data);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
