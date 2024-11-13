using System.ComponentModel.DataAnnotations;

namespace lab5.Models.DTO;

public class UpdateProjectDTO
{
    [StringLength(255)]
    public string ProjectName { get; set; }

    public string Description { get; set; }
}

