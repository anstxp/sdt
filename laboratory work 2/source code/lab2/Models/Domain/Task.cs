namespace lab2.Models.Domain;

public class Task
{
    public int TaskId { get; set; }
    public int ProjectId { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string PriorityId { get; set; }
    public string CategoryId { get; set; }
    public int AssigneeId { get; set; }
    public int SprintId { get; set; }

    public Project Project { get; set; }
    public User Assignee { get; set; }  
    public Sprint Sprint { get; set; }    
    public ICollection<File> Files { get; set;}

}