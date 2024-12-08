using lab7.Models.Domain.IdentityEntities;

namespace lab7.Models.Domain.Files;

public class UserProfileImage : BaseFile
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
}

