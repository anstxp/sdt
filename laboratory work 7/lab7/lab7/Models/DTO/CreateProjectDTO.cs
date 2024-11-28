using System.ComponentModel.DataAnnotations;

namespace lab7.Models.DTO;

public class CreateProjectDTO
{
    [System.ComponentModel.DataAnnotations.Required]
    [StringLength(255)]
    public string ProjectName { get; set; }

    public string Description { get; set; }
    [System.ComponentModel.DataAnnotations.Required]
    public Guid MethodologyId { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
    
    public ICollection<Guid> TeamIds { get; set; } = new List<Guid>();
}


