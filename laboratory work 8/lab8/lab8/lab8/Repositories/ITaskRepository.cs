using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITaskRepository
{
    Task<List<BaseTask>> GetTasksAsync(Guid projectId);
    Task<BaseTask?> GetTaskByIdAsync(Guid taskId);
    Task<BaseTask> CreateTaskAsync(BaseTask task);
    Task<bool> UpdateTaskAsync(BaseTask task);
    Task<bool> DeleteTaskAsync(Guid taskId);
    Task<List<BaseTask>> GetTasksByTeamIdAsync(Guid teamId);
}
