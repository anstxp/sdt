namespace WebApplication1.DTO;

public class TeamResponse
{
    public Guid TeamId { get; set; }
    public Guid ProjectId { get; set; }
    public string TeamName { get; set; }
    public Guid TeamLeadId { get; set; }
    public string TeamLeadFirstName { get; set; }
    public string TeamLeadLastName { get; set; }
    public string TeamLeadEmail { get; set; }
    public List<TeamMemberResponse> Members { get; set; } = new();
}