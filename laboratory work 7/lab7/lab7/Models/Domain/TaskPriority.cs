using System.ComponentModel.DataAnnotations;

namespace lab7.Models.Domain;

public class TaskPriority
{
    [Key]
    public Guid PriorityId { get; set; }

    [Required]
    [StringLength(100)]
    public string PriorityName { get; set; }

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
