namespace lab6.Models.Domain.Files;

public class TaskFile : BaseFile
{
    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public string VersionNumber { get; set; }
    public Guid? PreviousVersionId { get; set; }
    public TaskFile PreviousVersion { get; set; }
}

