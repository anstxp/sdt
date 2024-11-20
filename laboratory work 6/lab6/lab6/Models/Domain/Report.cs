using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6.Models.Domain;

public class Report
{
    [Key]
    public Guid ReportId { get; set; }

    [Required]
    [StringLength(50)]
    public string ReportType { get; set; } 

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public string Data { get; set; }
}