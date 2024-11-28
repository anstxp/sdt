namespace lab7.Models.DTO.FilesDTO;

public class TaskFileDTO : UploadFileDTO
{
    public Guid TaskId { get; set; }
    public Guid ProjectId { get; set; }
    public string VersionNumber { get; set; }
    public Guid PreviousVersionId { get; set; }
    
}