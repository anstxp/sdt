namespace lab2.Models.Domain;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<Task> Tasks { get; set;}
    public ICollection<Team> Teams { get; set; }
    public ICollection<Sprint> Sprints { get; set; }
    public ICollection<Version> Versions { get; set; }
}