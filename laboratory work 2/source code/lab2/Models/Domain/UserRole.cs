using System.ComponentModel.DataAnnotations;

namespace lab2.Models.Domain;

public class UserRole
{
    [Key]
    public int RoleId { get; set; }

    [Required, StringLength(100)]
    public string RoleName { get; set; }
}