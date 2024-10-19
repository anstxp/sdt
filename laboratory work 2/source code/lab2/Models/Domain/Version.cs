namespace lab2.Models.Domain;

public class Version
{
    public int VersionId { get; set; }
    public int ProjectId { get; set; }
    public string VersionNumber { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Project Project { get; set; }
    public ICollection<File> Files { get; set; }
}