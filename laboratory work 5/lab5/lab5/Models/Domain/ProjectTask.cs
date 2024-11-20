using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab5.Models.Domain.IdentityEntities;

namespace lab5.Models.Domain;

public class ProjectTask
{
    [Key]
    public Guid TaskId { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    public Project Project { get; set; }

    [Required]
    [StringLength(255)]
    public string TaskName { get; set; }

    public string Description { get; set; }

    [Required]
    public int PriorityId { get; set; }

    [ForeignKey("PriorityId")]
    public TaskPriority Priority { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public TaskCategory Category { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; } // e.g., "to-do", "in-progress", "done"

    public int AssigneeId { get; set; }

    [ForeignKey("AssigneeId")]
    public AppUser Assignee { get; set; }

    public int? SprintId { get; set; }

    [ForeignKey("SprintId")]
    public Sprint Sprint { get; set; }

    public ICollection<File> Files { get; set; } = new List<File>();
}