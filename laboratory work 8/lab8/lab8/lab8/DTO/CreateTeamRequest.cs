namespace WebApplication1.DTO;

public class CreateTeamRequest
{
    public Guid ProjectId { get; set; }
    public string TeamName { get; set; }
    public Guid TeamLeadId { get; set; }
    public ICollection<Guid> MemberIds { get; set; } = new List<Guid>();
    public List<MemberRoleRequest> MemberRoles { get; set; } = new List<MemberRoleRequest>();

}