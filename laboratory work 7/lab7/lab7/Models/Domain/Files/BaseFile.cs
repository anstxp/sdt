using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab7.Models.Domain.IdentityEntities;

namespace lab7.Models.Domain.Files;

public class BaseFile
{
    [Key]
    public Guid FileId { get; set; }
    [NotMapped]
    public IFormFile File { get; set; }
    [Required]
    public string FileName { get; set; }
    [Required]
    public string FileExtension { get; set; }
    [Required]
    public long FileSizeInBytes { get; set; }
    [Required]
    public string FileUrl { get; set; }
    public Guid UploadedByUserId { get; set; }
    public AppUser UploadedByUser { get; set; }
    public DateTime UploadedAt { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
}

