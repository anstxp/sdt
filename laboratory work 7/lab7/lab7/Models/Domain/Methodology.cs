using System.ComponentModel.DataAnnotations;
using lab7.Models.Domain;

namespace lab7.Models;

public class Methodology
{
    [Key]
    public Guid MethodologyId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
