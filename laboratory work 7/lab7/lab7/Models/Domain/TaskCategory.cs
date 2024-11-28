using System.ComponentModel.DataAnnotations;

namespace lab7.Models.Domain;

public class TaskCategory
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; }

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}