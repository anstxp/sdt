using System.ComponentModel.DataAnnotations;

namespace lab7.Models.DTO.AppUserDTO;

public class UploadImageDto
{
    [Required]
    public IFormFile File { get; set; }
}