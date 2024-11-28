using lab6.Data;
using lab6.Models.Domain.Files;
using lab6.Repositories.Interfaces.IFileRepositories;
using Microsoft.EntityFrameworkCore;

namespace lab6.Repositories.Implementation.FilesRepositories;

public class UserProfileImageRepository : FileRepository<UserProfileImage>, IUserProfileImageRepository
{
    public UserProfileImageRepository(AppDbContext context) : base(context) { }
    
    public async Task<UserProfileImage> GetProfileImageByUserIdAsync(Guid userId)
    {
        return await _context.UserProfileImages.FirstOrDefaultAsync(img => img.UserId == userId);
    }
    
    public async Task<UserProfileImage> ReplaceProfileImageAsync(UserProfileImage newImage)
    {
        var existingImage = await GetProfileImageByUserIdAsync(newImage.UserId);
        if (existingImage != null)
        {
            _context.UserProfileImages.Remove(existingImage);
        }

        await _context.UserProfileImages.AddAsync(newImage);
        await _context.SaveChangesAsync();

        return newImage;
    }
}

