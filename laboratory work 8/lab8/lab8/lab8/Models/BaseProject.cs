using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public abstract class BaseProject
{
    [Key]
    public Guid ProjectId { get; set; }
    [Required, StringLength(255)]
    public string ProjectName { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)] 
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)] 
    public DateTime? EndDate { get; set; }
    [Required]
    public Guid CreatorId { get; set; }
    public AppUser Creator { get; set; }
    [Required]
    [StringLength(255)]
    public string BlobDirectory { get; set; }
    [Required]
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<BaseTask> Tasks { get; set; } = new List<BaseTask>();
}