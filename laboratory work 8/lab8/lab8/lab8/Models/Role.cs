using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Role
{
    [Key]
    public Guid RoleId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public AccessLevel AccessLevel { get; set; }
    private Role() { }
    public Role(string name, string description, AccessLevel accessLevel)
    {
        Name = name;
        Description = description;
        AccessLevel = accessLevel;
    }
}

