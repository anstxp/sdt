using lab7.Models;
using lab7.Data;
using lab7.Repositories.Interfaces;

namespace lab7.Repositories.Implementation;

public class MethodologyRepository : IMethodologyRepository
{
    private readonly AppDbContext _context;

    public MethodologyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetMethodologyByIdAsync(Guid methodologyId)
    {
        var methodology =  await _context.Methodologies.FindAsync(methodologyId);
        return methodology.Name;
    }
}

