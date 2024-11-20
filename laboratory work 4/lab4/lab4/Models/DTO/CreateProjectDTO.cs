using System.ComponentModel.DataAnnotations;

namespace lab4.Models.DTO;

public class CreateProjectDTO
{
    [Required]
    [StringLength(255)]
    public string ProjectName { get; set; }

    public string Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
    
    public ICollection<Guid> TeamIds { get; set; } = new List<Guid>();
}


