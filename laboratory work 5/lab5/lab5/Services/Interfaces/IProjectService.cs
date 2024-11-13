using lab5.Models.Domain;
using lab5.Models.DTO;
using Task = System.Threading.Tasks.Task;

namespace lab5.Services.Interfaces;

public interface IProjectService
{
    Task<Project> CreateProjectAsync(string Id, CreateProjectDTO dto);
    Task<Project> UpdateProjectAsync(Guid projectId, UpdateProjectDTO dto);
    Task<bool> DeleteProjectAsync(Guid id);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(Guid id);
}