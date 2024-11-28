namespace lab7.Models.DTO.FilesDTO;

public class ReportFileDTO : UploadFileDTO
{
    public Guid ReportId { get; set; }
    public Guid ProjectId { get; set; }
}