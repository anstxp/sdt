using lab6.Data;
using lab6.Models.Domain;
using lab6.Models.DTO;
using lab6.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace lab6.Repositories.Implementation;

public class ProjectRepository: IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Project?>> GetAllAsync()
    {
        var projects = _context.Projects
            .Include(p => p.Teams)
            .Include(p => p.Tasks)
            .AsQueryable();
        return await projects.ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(Guid projectId)
    {
        return await _context.Projects
            .Include(p => p.Teams)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.ProjectId == projectId);
    }
    
    public async Task<Project?> GetByNameAsync(string name)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectName == name);
    }
    
    public async Task<bool> DeleteProjectAsync(Guid projectId)
    {
        var project = await _context.Projects.FindAsync(projectId);
        if (project == null)
        {
            throw new InvalidOperationException("Project not found.");
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public async Task<Project?> CreateProjectAsync(CreateProjectDTO dto)
    {
        var project = new Project
        {
            ProjectId = Guid.NewGuid(),
            ProjectName = dto.ProjectName,
            MethodologyId = dto.MethodologyId,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        foreach (var teamId in dto.TeamIds)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team != null)
                project.Teams.Add(team);
        }

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }
    
    public async Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject == null)
        {
            return null;
        }
        
        existingProject.ProjectName = project.ProjectName;
        existingProject.Description = project.Description;
        
        await _context.SaveChangesAsync();
        return existingProject;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}