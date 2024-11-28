using lab6.Data;
using lab6.Models.Domain.Files;
using lab6.Repositories.Interfaces;
using lab6.Repositories.Interfaces.IFileRepositories;
using Microsoft.EntityFrameworkCore;

namespace lab6.Repositories.Implementation.FilesRepositories;

public class ReportFileRepository : FileRepository<ReportFile>, IReportFileRepository
{
    public ReportFileRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<ReportFile>> GetAllByProjectIdAsync(Guid projectId)
    {
        return await _context.Set<ReportFile>()
            .Where(rf => rf.ProjectId == projectId)
            .ToListAsync();
    }
}


