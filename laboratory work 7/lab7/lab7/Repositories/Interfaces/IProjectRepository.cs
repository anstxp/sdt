using lab7.Models.Domain;
using lab7.Models.DTO;

namespace lab7.Repositories.Interfaces;

public interface IProjectRepository : IDisposable
{
    Task<List<Project?>> GetAllAsync();
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project?> GetByNameAsync(string  name);
    Task<Project?> CreateProjectAsync(CreateProjectDTO project);
    Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project);
    Task<bool> DeleteProjectAsync(Guid id);
}
