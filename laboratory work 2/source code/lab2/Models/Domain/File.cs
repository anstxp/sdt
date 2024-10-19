namespace lab2.Models.Domain;

public class File
{
    public int FileId { get; set; }
    public int TaskId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int VersionId { get; set; }

    public Task Task { get; set; }
    public Version Version { get; set; }    
}
