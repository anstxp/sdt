using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

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
    public string ProfilePictureUrl { get; set; } =
        "https://dotlystorage.blob.core.windows.net/user-photos-container/default-photo.png";
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
    public ICollection<BaseTask> Tasks { get; set; } = new List<BaseTask>();
    public ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
}
