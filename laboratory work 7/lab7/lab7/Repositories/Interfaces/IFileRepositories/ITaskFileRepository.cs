using lab7.Models.Domain.Files;

namespace lab7.Repositories.Interfaces.IFileRepositories;

public interface ITaskFileRepository : IFileRepository<TaskFile>
{
    Task<TaskFile?> GetLatestVersionAsync(Guid taskId);
    Task<IEnumerable<TaskFile>> GetAllVersionsAsync(Guid taskId);
}