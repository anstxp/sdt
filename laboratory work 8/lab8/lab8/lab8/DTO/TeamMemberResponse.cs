namespace WebApplication1.DTO;

public class TeamMemberResponse
{ 
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string RoleName { get; set; }
    public string AccessLevel { get; set; }
}