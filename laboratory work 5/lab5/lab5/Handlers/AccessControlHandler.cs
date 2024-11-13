using lab5.Models.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace lab5.Handlers;

public class AccessControlHandler : IRequestHandler
{
    private readonly UserManager<AppUser> _userManager;
    
    private readonly List<string> _allowedRolesForProject = new List<string> { "Admin", "PM" };
    private readonly List<string> _allowedRolesForTask = new List<string> { "Admin", "PM", "User" };

    public AccessControlHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task HandleAsync(Request request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            throw new UnauthorizedAccessException("User not found.");
        }
    
        var roles = await _userManager.GetRolesAsync(user);

        if (request.ResourceType == "Project" && !_allowedRolesForProject.Any(role => roles.Contains(role)))
        {
            throw new UnauthorizedAccessException
                ("You do not have the required role to perform this action on Project.");
        }

        if (request.ResourceType == "Task" && !_allowedRolesForTask.Any(role => roles.Contains(role)))
        {
            throw new UnauthorizedAccessException
                ("You do not have the required role to perform this action on Task.");
        }

        if (Next != null)
        {
            await Next.HandleAsync(request);
        }
    }

    public IRequestHandler? Next { get; set; }
}




