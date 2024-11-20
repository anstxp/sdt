using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab5.Models.Domain.IdentityEntities;

namespace lab5.Models.Domain;

public class TeamMember
{
    [Key]
    public Guid TeamMemberId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public AppUser User { get; set; }

    [Required]
    public int TeamId { get; set; }

    [ForeignKey("TeamId")]
    public Team Team { get; set; }

    [StringLength(100)]
    public string SubRole { get; set; }

    [Range(0, 1000000)]
    public decimal Salary { get; set; }

    public string AdditionalData { get; set; }
}