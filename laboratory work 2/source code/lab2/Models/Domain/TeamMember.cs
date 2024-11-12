namespace lab2.Models.Domain;

public class TeamMember
{
    public int TeamMemberId { get; set; }
    public int UserId { get; set; }
    public int TeamId { get; set; }
    public string SubRole { get; set; }
    public decimal Salary { get; set; }
    public string AdditionalData { get; set; }

    public User User { get; set; }
    public Team Team { get; set; }
}