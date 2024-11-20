using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab5.Models.Domain;

public class Version
{
    [Key]
    public Guid VersionId { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    public Project Project { get; set; }

    [Required]
    [StringLength(50)]
    public string VersionNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    public ICollection<File> Files { get; set; } = new List<File>();
}