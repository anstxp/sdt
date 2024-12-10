using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Team
{
    [Key]
    public Guid TeamId { get; set; }
    [Required]
    public Guid ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public BaseProject Project { get; set; }
    [Required]
    public Guid TeamLeadId { get; set; }
    [ForeignKey(nameof(TeamLeadId))]
    public AppUser TeamLead { get; set; }
    [Required]
    [StringLength(255)]
    public string TeamName { get; set; }
    public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    public ICollection<BaseTask> Tasks { get; set; } = new List<BaseTask>();
}