namespace lab2.Models.Domain;

public class TaskPriority
{
    public int PriorityId { get; set; }
    public string PriorityName { get; set; }

    public ICollection<Task> Tasks { get; set; }
}