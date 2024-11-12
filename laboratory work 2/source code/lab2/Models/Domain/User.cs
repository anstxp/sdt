using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models.Domain;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required, StringLength(255)]
    public string Username { get; set; }

    [Required, StringLength(255)]
    public string Password { get; set; }

    [Required, StringLength(255), EmailAddress]
    public string Email { get; set; }

    [ForeignKey("UserRole")]
    public int RoleId { get; set; }
    public UserRole UserRole { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}