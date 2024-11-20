using System.ComponentModel.DataAnnotations;

namespace lab4.Models.Domain;

public class TaskCategory
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(100)]
    public string CategoryName { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}