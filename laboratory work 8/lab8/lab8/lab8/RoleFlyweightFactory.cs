using WebApplication1.Models;

namespace WebApplication1;

public class RoleFlyweightFactory
{
    private readonly Dictionary<string, Role> _roles = 
        new Dictionary<string, Role>(StringComparer.OrdinalIgnoreCase);

    public Role GetRole(string name, string description, AccessLevel accessLevel)
    {
        var key = $"{name}_{(int)accessLevel}";
        if (!_roles.TryGetValue(key, out var role))
        {
            role = new Role(name, description, accessLevel);
            _roles[key] = role;
        }
        return role;
    }
    public Role GetDefaultRole()
    {
        return GetRole("Developer", "Default role for team members", 
            AccessLevel.TaskExecution);
    }

    public List<Role> GetAllRoles()
    {
        return _roles.Values.ToList();
    }
    public void PreloadRoles()
    {
        GetRole("Administrator", "Admin role with full permissions", 
            AccessLevel.FullAccess);
        GetRole("Scrum Master", "Manages iterations and planning", 
            AccessLevel.IterationManagement);
        GetRole("Team Lead", "Manages team tasks", 
            AccessLevel.TaskManagement);
        GetRole("Developer", "Executes tasks", 
            AccessLevel.TaskExecution);
        GetRole("Restricted", "Limited access role", 
            AccessLevel.RestrictedAccess);
    }
}

