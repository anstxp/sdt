using System.ComponentModel.DataAnnotations;

namespace lab6.Models.DTO;

public class UpdateProjectDTO
{
    [StringLength(255)]
    public string ProjectName { get; set; }

    public string Description { get; set; }
}

