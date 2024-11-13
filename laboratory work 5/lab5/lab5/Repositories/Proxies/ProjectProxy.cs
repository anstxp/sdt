using lab5.Models.Domain;
using lab5.Models.DTO;
using lab5.Repositories.Implementation;
using lab5.Repositories.Interfaces;

namespace lab5.Repositories.Proxies;

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

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        Console.WriteLine($"Getting project with ID: {id}");
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<Project?> GetByNameAsync(string name)
    {
        Console.WriteLine($"Getting project with ProjectName: {name}");
        return await _projectRepository.GetByNameAsync(name);
    }

    public async Task<Project?> CreateProjectAsync(CreateProjectDTO project)
    {
        var createdProject = await _projectRepository.CreateProjectAsync(project);
        _cachedProjects = null;
        return createdProject;
    }

    public async Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project)
    {
        var updatedProject = await _projectRepository.UpdateProjectAsync(id, project);
        _cachedProjects = null;
        return updatedProject;
    }

    public async Task<bool> DeleteProjectAsync(Guid id)
    {
        var deleted = await _projectRepository.DeleteProjectAsync(id);
        if (deleted)
        {
            _cachedProjects = null;
        }
        return deleted;
    }

    public void Dispose()
    {
        _projectRepository.Dispose();
    }
}


