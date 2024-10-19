namespace lab2.Models.Domain;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public UserRole UserRole { get; set; }
    public ICollection<TeamMember> TeamMember { get; set; }
    public ICollection<Task> Tasks { get; set; }

}