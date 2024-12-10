using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProjectRepository
    {
        Task<BaseProject> CreateAsync(BaseProject project);
        Task<List<BaseProject>> GetAllForUserAsync(Guid userId);
        Task<BaseProject?> GetByNameAsync(string name);
        Task<bool> RemoveTeamFromProjectAsync(Guid projectId, Guid teamId);
        Task<bool> UpdateAsync(BaseProject project);
        Task<bool> DeleteAsync(Guid projectId);
        Task<BaseProject?> GetByIdAsync(Guid projectId);
    }
}