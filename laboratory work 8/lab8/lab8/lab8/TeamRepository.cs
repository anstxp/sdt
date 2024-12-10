using DotlyApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetTeamsByProjectIdAsync(Guid projectId)
    {
        return await _context.Teams
            .Include(t => t.TeamMembers)
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task<List<Team>> GetTeamsByTaskIdAsync(Guid taskId)
    {
        var task = await _context.Tasks
            .Include(t => t.Team) 
            .ThenInclude(team => team.TeamMembers)
            .FirstOrDefaultAsync(t => t.TaskId == taskId);

        if (task == null || task.Team == null)
            return new List<Team>();

        return new List<Team> { task.Team };
    }
    
    public async Task<Team> GetByIdAsync(Guid teamId)
    {
        return await _context.Teams
            .Include(t => t.TeamMembers)
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
    }

    public async Task AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid teamId)
    {
        var hasTasks = await _context.Tasks.AnyAsync(t => t.TeamId == teamId);
        if (hasTasks)
            throw new InvalidOperationException("Cannot delete a team that has associated tasks.");
        var team = await GetByIdAsync(teamId);
        if (team != null)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTeamMemberAsync(TeamMember teamMember)
    {
        await _context.TeamMembers.AddAsync(teamMember);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTeamMemberAsync(Guid teamId, Guid userId)
    {
        var teamMember = await _context.TeamMembers
            .FirstOrDefaultAsync(tm => tm.TeamId == teamId && tm.UserId == userId);
        if (teamMember != null)
        {
            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task UpdateTeamMemberAsync(TeamMember teamMember)
    {
        _context.TeamMembers.Update(teamMember);
        await _context.SaveChangesAsync();
    }
    
    public async Task<TeamMember?> GetTeamMemberAsync(Guid teamId, Guid userId)
    {
        return await _context.TeamMembers
            .FirstOrDefaultAsync(tm => tm.TeamId == teamId && tm.UserId == userId);
    }
    
    public async Task<Team> GetTeamForProjectAsync(Guid teamId, Guid projectId)
    {
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId && t.ProjectId == projectId);

        if (team == null)
            throw new ArgumentException("Invalid team or team does not belong to the project.");

        return team;
    }

}