using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public abstract class BaseTask
{
    [Key]
    public Guid TaskId { get; set; }
    [Required]
    public Guid ProjectId { get; set; }
    [ForeignKey(nameof(ProjectId))]
    public BaseProject Project { get; set; }
    [Required, StringLength(255)]
    public string TaskName { get; set; }
    public string Description { get; set; }
    [Required]
    public TaskStatus Status { get; set; }
    public Guid? TaskCategoryId { get; set; }
    [ForeignKey(nameof(TaskCategoryId))]
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public Guid TeamId { get; set; }

    [ForeignKey(nameof(TeamId))]
    public Team Team { get; set; }
}
