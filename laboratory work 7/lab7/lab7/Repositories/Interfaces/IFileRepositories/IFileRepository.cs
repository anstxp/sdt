using lab6.Models.Domain.Files;

namespace lab6.Repositories.Interfaces.IFileRepositories;

public interface IFileRepository<TFile> where TFile : BaseFile
{
    Task<TFile> AddAsync(TFile file);
    Task<TFile> GetByIdAsync(Guid fileId);
    Task<IEnumerable<TFile>> GetAllByUserIdAsync(Guid userId);
    Task DeleteAsync(Guid fileId);
}
