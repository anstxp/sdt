using DotlyApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BaseTask>> GetTasksAsync(Guid projectId)
    {
        return await _context.Set<BaseTask>()
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task<BaseTask?> GetTaskByIdAsync(Guid taskId)
    {
        return await _context.Set<BaseTask>().FirstOrDefaultAsync(t => t.TaskId == taskId);
    }

    public async Task<BaseTask> CreateTaskAsync(BaseTask task)
    {
        _context.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateTaskAsync(BaseTask task)
    {
        _context.Update(task);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTaskAsync(Guid taskId)
    {
        var task = await GetTaskByIdAsync(taskId);
        if (task == null) return false;

        _context.Remove(task);
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<List<BaseTask>> GetTasksByTeamIdAsync(Guid teamId)
    {
        return await _context.Tasks
            .Where(t => t.TeamId == teamId)
            .ToListAsync();
    }
}
