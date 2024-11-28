using lab7.Models.Domain;
using lab7.Repositories.Interfaces;
using lab7.Models.Domain.Files;
using lab7.Models.DTO.AppUserDTO;
using lab7.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileImageController: Controller
{
    private readonly IFileService _fileService;

    public UserProfileImageController(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPost("{userId}/upload-profile-picture")]
    public async Task<IActionResult> UploadProfilePicture(Guid userId, UploadImageDto profilePicture)
    {
        ValidateFileUpload(profilePicture);
        
        if (ModelState.IsValid)
        {
            DateTime now = DateTime.Now;
            var imageDomainModel = new UserProfileImage()
            {
                File = profilePicture.File,
                FileExtension = Path.GetExtension(profilePicture.File.FileName),
                FileSizeInBytes = profilePicture.File.Length,
                FileName = $"{userId}_profile_{now.ToString("yyyyMMdd_HHmmss")}",
                UserId = userId,
                
            };
            
            var fileStream = profilePicture.File.OpenReadStream();
            var filePath = $"user-profiles/{userId}/{imageDomainModel.FileName}";
            await _fileService.UploadFileAsync(fileStream, filePath, isPublic: true);
            return Ok(new { ProfilePictureUrl = filePath });

        }
        
        return BadRequest(ModelState);
    }
    
    private void ValidateFileUpload(UploadImageDto request)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
        {
            ModelState.AddModelError("file", "Unsupported file extension");
        }

        if (request.File.Length > 10485760)
        {
            ModelState.AddModelError("file", 
                "File size more than 10MB, please upload a smaller size file");
        }
    }
}