using System.ComponentModel.DataAnnotations;

namespace lab5.Models.Domain;

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
    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}