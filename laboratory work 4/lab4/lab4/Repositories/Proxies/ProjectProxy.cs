using lab4.Models.Domain;
using lab4.Models.DTO;
using lab4.Repositories.Implementation;
using lab4.Repositories.Interfaces;

namespace lab4.Repositories.Proxies;

public class ProjectProxy : IProjectRepository
{
    private readonly ProjectRepository _projectRepository;
    private List<Project?>? _cachedProjects;

    public ProjectProxy(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<Project?>> GetAllAsync()
    {
        if (_cachedProjects == null)
        {
            Console.WriteLine("Loading all projects from the database...");
            _cachedProjects = await _projectRepository.GetAllAsync();
        }
        else
        {
            Console.WriteLine("Retrieving all projects from cache...");
        }
        
        return _cachedProjects;
    }

    public Task<Project?> GetByIdAsync(Guid id)
    {
        Console.WriteLine($"Getting project with ID: {{id}}");
        return _projectRepository.GetByIdAsync(id);
    }

    public Task<Project?> CreateProjectAsync(CreateProjectDTO project)
    {
        return _projectRepository.CreateProjectAsync(project);
    }

    public Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project)
    {
        return _projectRepository.UpdateProjectAsync(id, project);    
    }

    public Task<bool> DeleteProjectAsync(Guid id)
    {
        return _projectRepository.DeleteProjectAsync(id);    

    }
    
    public void Dispose()
    {
        _projectRepository.Dispose();
    }
}
