using WebApplication1.Models;

namespace WebApplication1;

public interface ITeamRepository
{
    Task<List<Team>> GetTeamsByProjectIdAsync(Guid projectId);
    Task<List<Team>> GetTeamsByTaskIdAsync(Guid taskId);
    Task<Team> GetByIdAsync(Guid teamId);
    Task AddAsync(Team team);
    Task UpdateAsync(Team team);
    Task RemoveAsync(Guid teamId);
    Task AddTeamMemberAsync(TeamMember teamMember);
    Task RemoveTeamMemberAsync(Guid teamId, Guid userId);
    Task<TeamMember?> GetTeamMemberAsync(Guid teamId, Guid userId);
    Task UpdateTeamMemberAsync(TeamMember teamMember);
    Task<Team> GetTeamForProjectAsync(Guid teamId, Guid projectId);
}