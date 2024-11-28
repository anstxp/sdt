using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6.Models.Domain;

public class Team
{
    [Key]
    public Guid TeamId { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [ForeignKey("ProjectId")]
    public Project Project { get; set; }

    [Required]
    [StringLength(255)]
    public string TeamName { get; set; }

    public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
