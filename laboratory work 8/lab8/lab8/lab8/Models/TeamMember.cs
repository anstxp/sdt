using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class TeamMember
{
    [Key]
    public Guid TeamMemberId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public AppUser User { get; set; }
    [ForeignKey("RoleId")]
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    [Required]
    public Guid TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
    [Range(0, 1000000)]
    public int Salary { get; set; }
    public TeamMember() { }
    public TeamMember(Guid teamMemberId, Guid teamId, Guid userId, Role role, int salary)
    {
        TeamMemberId = teamMemberId;
        TeamId = teamId;
        UserId = userId;
        Role = role;
        Salary = salary;
    }
    public void UpdateRole(Role role)
    {
        Role = role;
    }
}

