using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IUserRepository
{
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<AppUser?> GetUserByEmailAsync(string email);
    Task<AppUser?> GetUserByIdlAsync(Guid id);
    Task<List<AppUser>> GetByIdsAsync(IEnumerable<Guid> ids);

}