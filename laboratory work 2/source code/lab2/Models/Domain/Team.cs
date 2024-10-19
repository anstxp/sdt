namespace lab2.Models.Domain;

public class Team
{
    public int TeamId { get; set; }
    public int ProjectId { get; set; }
    public string TeamName { get; set; }

    public Project Project { get; set; }
    public ICollection<TeamMember> TeamMembers { get; set;}
}