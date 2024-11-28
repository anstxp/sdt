using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace lab7.Models.Domain.IdentityEntities;

public class AppUser : IdentityUser<Guid>
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    public string ProfilePictureUrl { get; set; }

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    public ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
}