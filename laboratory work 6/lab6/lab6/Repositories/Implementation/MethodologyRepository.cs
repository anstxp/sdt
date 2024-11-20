using lab6.Models;
using lab6.Data;
using lab6.Repositories.Interfaces;

namespace lab6.Repositories.Implementation;

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

