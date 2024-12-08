using lab7.Models.Domain;
using lab7.Models.DTO;
using Task = System.Threading.Tasks.Task;

namespace lab7.Services.Interfaces;

public interface IProjectService
{
    Task<Project> CreateProjectAsync(string userId, CreateProjectDTO dto);
    Task<Project> UpdateProjectAsync(Guid projectId, UpdateProjectDTO dto);
    Task<bool> DeleteProjectAsync(Guid id);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(Guid id);
}