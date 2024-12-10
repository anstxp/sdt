using DotlyApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace DotlyApi.Repositories.Implementations;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<BaseProject> _dbSet;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<BaseProject>();
    }

    public async Task<BaseProject> CreateAsync(BaseProject project)
    {
        await _dbSet.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<List<BaseProject>> GetAllForUserAsync(Guid userId)
    {
        return await _dbSet
            .Include(p => p.Teams)
            .ThenInclude(t => t.TeamMembers)
            .ThenInclude(tt => tt.User)
            .Where(p => p.Teams.Any(t => t.TeamMembers.Any(tm => tm.UserId == userId)))
            .ToListAsync();
    }

    public async Task<BaseProject?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.ProjectName == name);
    }

    public async Task<BaseProject?> GetByIdAsync(Guid projectId)
    {
        return await _dbSet.
            Include(p => p.Teams)
            .ThenInclude(t => t.TeamMembers)
            .ThenInclude(tt => tt.User)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);
    }

    public async Task<bool> RemoveTeamFromProjectAsync(Guid projectId, Guid teamId)
    {
        var team = await _context.Teams.FindAsync(teamId);
        if (team == null || team.ProjectId != projectId) return false;

        _context.Teams.Remove(team);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(BaseProject project)
    {
        var existingProject = await _dbSet.FindAsync(project.ProjectId);
        if (existingProject == null) return false;

        _context.Entry(existingProject).CurrentValues.SetValues(project);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid projectId)
    {
        var project = await _dbSet
            .Include(p => p.Teams)
            .ThenInclude(t => t.TeamMembers)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);

        if (project == null) return false;

        // Видалити членів команд
        foreach (var team in project.Teams)
        {
            _context.TeamMembers.RemoveRange(team.TeamMembers);
        }

        // Видалити команди
        _context.Teams.RemoveRange(project.Teams);

        // Видалити сам проект
        _dbSet.Remove(project);

        return await _context.SaveChangesAsync() > 0;
    }
}
