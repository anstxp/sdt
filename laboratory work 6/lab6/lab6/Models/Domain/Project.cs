using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab6.Factories.Methologies;

namespace lab6.Models.Domain;

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
    [Required]
    public Guid MethodologyId { get; set; }
    public Methodology Methodology { get; set; }
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
}