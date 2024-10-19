namespace lab2.Models.Domain;

public class Report
{
    public int ReportId { get; set; }
    public string ReportType { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Data { get; set; }
}
