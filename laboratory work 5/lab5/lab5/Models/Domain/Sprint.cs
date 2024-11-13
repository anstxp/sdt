using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab5.Models.Domain;

public class Sprint
{
    [Key]
    public Guid SprintId { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    public Project Project { get; set; }

    [Required]
    [StringLength(255)]
    public string SprintName { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}