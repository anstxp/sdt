namespace lab2.Models.Domain;

public class Sprint
{
    public int SprintId { get; set; }
    public int ProjectId { get; set; }
    public string SprintName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Project Project { get; set; }
    public ICollection<Task> Tasks { get;}
}