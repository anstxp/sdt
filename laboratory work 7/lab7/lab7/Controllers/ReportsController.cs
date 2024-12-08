using lab7.Repositories.Interfaces;
using lab7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IFileService _fileService;

    public ReportsController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost("{projectId}/upload-report")]
    public async Task<IActionResult> UploadReport(Guid projectId, Guid userId, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is required.");
        }

        var fileStream = file.OpenReadStream();
        var filePath = $"projects/{projectId}/reports/{userId}/{Guid.NewGuid()}.pdf";

        await _fileService.UploadFileAsync(fileStream, filePath, isPublic: false);

        return Ok(new { FilePath = filePath });
    }
}
