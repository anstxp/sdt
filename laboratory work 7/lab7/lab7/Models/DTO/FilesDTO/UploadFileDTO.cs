namespace lab7.Models.DTO.FilesDTO;

public class UploadFileDTO
{
    public Stream FileStream { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public long FileSizeInBytes { get; set; }
    public bool IsPublic { get; set; }
    public Guid UploadedByUserId { get; set; }
    public string Description { get; set; }
}