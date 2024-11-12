using Microsoft.AspNetCore.Identity;

namespace lab4.Models.Domain.IdentityEntities;

public class AppUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }    
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int Salary { get; set; }
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    public ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
}