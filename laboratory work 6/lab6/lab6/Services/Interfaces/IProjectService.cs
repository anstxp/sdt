using lab6.Models.Domain;
using lab6.Models.DTO;
using Task = System.Threading.Tasks.Task;

namespace lab6.Services.Interfaces;

public interface IProjectService
{
    Task<Project> CreateProjectAsync(string userId, CreateProjectDTO dto);
    Task<Project> UpdateProjectAsync(Guid projectId, UpdateProjectDTO dto);
    Task<bool> DeleteProjectAsync(Guid id);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(Guid id);
}