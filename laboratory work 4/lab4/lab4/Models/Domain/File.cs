using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.Models.Domain;

public class File
{
    [Key]
    public Guid FileId { get; set; }

    [Required]
    public int TaskId { get; set; }

    [ForeignKey("TaskId")]
    public Task Task { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; }

    [Required]
    [StringLength(255)]
    public string FilePath { get; set; }

    public int? VersionId { get; set; }

    [ForeignKey("VersionId")]
    public Version Version { get; set; }
}