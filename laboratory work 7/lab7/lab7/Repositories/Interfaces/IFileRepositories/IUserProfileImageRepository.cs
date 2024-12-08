using lab7.Models.Domain.Files;

namespace lab7.Repositories.Interfaces.IFileRepositories;

public interface IUserProfileImageRepository : IFileRepository<UserProfileImage>
{
    Task<UserProfileImage> ReplaceProfileImageAsync(UserProfileImage newImage);
    Task<UserProfileImage> GetProfileImageByUserIdAsync(Guid userId);

}