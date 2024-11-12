using lab4.Models.Domain;
using lab4.Models.DTO;

namespace lab4.Repositories.Interfaces;

public interface IProjectRepository : IDisposable
{
    Task<List<Project?>> GetAllAsync();
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project?> CreateProjectAsync(CreateProjectDTO project);
    Task<Project?> UpdateProjectAsync(Guid id, UpdateProjectDTO project);
    Task<bool> DeleteProjectAsync(Guid id);
}
