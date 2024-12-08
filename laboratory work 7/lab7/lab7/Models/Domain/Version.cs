using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab7.Models.Domain.Files;
using lab7.Models.Domain.IdentityEntities;

namespace lab7.Models.Domain;

public class Version
{
    [Key]
    public Guid VersionId { get; set; }

    [Required]
    public Guid FileId { get; set; }

    [ForeignKey("FileId")]
    public TaskFile File { get; set; }

    [Required]
    public string VersionNumber { get; set; } // Наприклад, "v1.0", "v2.1"

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public Guid UploadedByUserId { get; set; }

    [ForeignKey("UploadedByUserId")]
    public AppUser UploadedByUser { get; set; }

    [Required]
    [StringLength(500)]
    public string FileUrl { get; set; }
}