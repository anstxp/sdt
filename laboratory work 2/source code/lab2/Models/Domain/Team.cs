using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models.Domain;

public class Team
{
    [Key]
    public int TeamId { get; set; }

    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    [Required, StringLength(255)]
    public string TeamName { get; set; }
}