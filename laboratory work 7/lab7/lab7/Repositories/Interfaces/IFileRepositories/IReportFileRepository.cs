using lab7.Models.Domain.Files;

namespace lab7.Repositories.Interfaces.IFileRepositories;

public interface IReportFileRepository : IFileRepository<ReportFile>
{
    Task<IEnumerable<ReportFile>> GetAllByProjectIdAsync(Guid projectId);
}