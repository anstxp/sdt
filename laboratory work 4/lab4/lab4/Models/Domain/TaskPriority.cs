using System.ComponentModel.DataAnnotations;

namespace lab4.Models.Domain;

public class TaskPriority
{
    [Key]
    public Guid PriorityId { get; set; }

    [Required]
    [StringLength(100)]
    public string PriorityName { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}
