using System.ComponentModel.DataAnnotations;

namespace lab4.Models.Domain;

public class Project
{
    [Key]
    public Guid ProjectId { get; set; }

    [Required]
    [StringLength(255)]
    public string ProjectName { get; set; }

    public string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}