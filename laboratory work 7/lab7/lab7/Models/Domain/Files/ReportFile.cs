using System.ComponentModel.DataAnnotations;

namespace lab6.Models.Domain.Files;

public class ReportFile : BaseFile
{
    [Required]
    public Guid ReportId { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}

