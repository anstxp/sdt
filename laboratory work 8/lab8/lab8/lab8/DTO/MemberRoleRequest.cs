using WebApplication1.Models;

namespace WebApplication1.DTO;

public class MemberRoleRequest
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; }
    public AccessLevel AccessLevel { get; set; }
}