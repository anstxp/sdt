using DotlyApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<AppUser?> GetUserByEmailAsync(string email)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<AppUser?> GetUserByIdlAsync(Guid id)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Id == id);    
    }
    
    public async Task<List<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.AppUsers
            .Where(user => ids.Contains(user.Id))
            .ToListAsync();
    }
}