using lab6.Data;
using lab6.Models.Domain.Files;
using lab6.Repositories.Interfaces;
using lab6.Repositories.Interfaces.IFileRepositories;
using Microsoft.EntityFrameworkCore;

namespace lab6.Repositories.Implementation.FilesRepositories;

public class FileRepository<TFile> : IFileRepository<TFile> where TFile : BaseFile
{
    protected readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TFile> AddAsync(TFile file)
    {
        await _context.Set<TFile>().AddAsync(file);
        await _context.SaveChangesAsync();
        return file;
    }

    public async Task<TFile> GetByIdAsync(Guid fileId)
    {
        return await _context.Set<TFile?>().FindAsync(fileId);
    }

    public async Task<IEnumerable<TFile>> GetAllByUserIdAsync(Guid userId)
    {
        return await _context.Set<TFile>()
            .Where(f => f.UploadedByUserId == userId)
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid fileId)
    {
        var file = await _context.Set<TFile>().FindAsync(fileId);
        if (file != null)
        {
            _context.Set<TFile>().Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
