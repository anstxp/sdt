using lab6.Data;
using lab6.Models.Domain.Files;
using lab6.Repositories.Interfaces.IFileRepositories;
using Microsoft.EntityFrameworkCore;

namespace lab6.Repositories.Implementation.FilesRepositories;

public class TaskFileRepository : FileRepository<TaskFile>, ITaskFileRepository
{
    public TaskFileRepository(AppDbContext context) : base(context) { }

    public async Task<TaskFile?> GetLatestVersionAsync(Guid taskId)
    {
        return await _context.Set<TaskFile>()
            .Where(tf => tf.TaskId == taskId)
            .OrderByDescending(tf => tf.VersionNumber)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TaskFile>> GetAllVersionsAsync(Guid taskId)
    {
        return await _context.Set<TaskFile>()
            .Where(tf => tf.TaskId == taskId)
            .OrderBy(tf => tf.VersionNumber)
            .ToListAsync();
    }
}

